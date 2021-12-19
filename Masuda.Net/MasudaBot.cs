using Masuda.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Masuda.Net
{
    public enum BotType
    {
        Public,
        PublicSandBox,
        Private,
        PrivateSandBox,
    }

    public partial class MasudaBot
    {
        private HttpClient _httpClient = new HttpClient();
        private int _appId;
        private string _apiKey;
        private string _token;

        //private string _testUrl = "https://sandbox.api.sgroup.qq.com";
        private string _testUrl = "https://api.sgroup.qq.com";
        private int _heartbeatInterval = 45000;
        private CancellationTokenSource _cts = new CancellationTokenSource(35000);
        protected ClientWebSocket _webSocket = new ClientWebSocket();
        private int _lastS = 1;
        private int _shardCnt = 1;
        private int _shardId = -1;
        /// <summary>
        /// 心跳计时器
        /// </summary>
        private Timer _timer;
        private string _sessionId = null;
        private Intent[] _intents = new [] {Intent.AT_MESSAGES, Intent.GUILDS, Intent.GUILD_MEMBERS, Intent.GUILD_MESSAGE_REACTIONS};
        private Task _botTask;
        private Dictionary<string, string> _guildName = new Dictionary<string, string>();
        private Dictionary<string, string> _channelName = new Dictionary<string, string>();
        private bool _log = false;

        private DateTime _lastUpdateTime = DateTime.MinValue;

        /// <summary>
        /// 收到At消息
        /// </summary>
        public event Action<MasudaBot, Message, ActionType> AtMessageAction;
        /// <summary>
        /// 收到普通消息
        /// </summary>
        public event Action<MasudaBot, Message, ActionType> MessageAction;
        //public event Action<MasudaBot, Message, ActionType> NormalMessageAction;
        /// <summary>
        /// 音频事件
        /// </summary>
        public event Action<MasudaBot, AudioAction, ActionType> AudioAction;
        /// <summary>
        /// 直接消息事件（未开放）
        /// </summary>
        public event Action<MasudaBot, Message, ActionType> DircetAction;
        /// <summary>
        /// 论坛事件（未开放）
        /// </summary>
        public event Action<MasudaBot, object, ActionType> ForumAction;
        /// <summary>
        /// 表情表态事件
        /// </summary>
        public event Action<MasudaBot, MessageReaction, ActionType> GuildMessageReAction;
        /// <summary>
        /// 频道成员事件
        /// </summary>
        public event Action<MasudaBot, MemberWithGuildID, ActionType> GuildMembersAction;
        /// <summary>
        /// 频道事件
        /// </summary>
        public event Action<MasudaBot, Guild, ActionType> GuildAction;
        /// <summary>
        /// 子频道事件
        /// </summary>
        public event Action<MasudaBot, Channel, ActionType> ChannelAction;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appKey"></param>
        /// <param name="token"></param>
        /// <param name="sendbox"></param>
        /// <param name="shardId">不给则默认全接受</param>
        /// <param name="log">是否给出log</param>
        /// <param name=""></param>
        public MasudaBot(int appId, string appKey, string token, bool sandbox = false, int shardId = -1, Intent[] intents = null, bool log = true)
        {
            _apiKey = appKey;
            _token = token;
            _appId = appId;
            _log = log;
            _shardId = shardId;
            //"authorization", $"Bot {_appId}.{_token}"
            _httpClient.DefaultRequestHeaders.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bot",$"{_appId}.{_token}");
            if (sandbox)
                _testUrl = "https://sandbox.api.sgroup.qq.com";
            if (intents != null)
                _intents = intents;
            _botTask = WebSocketInit();
            //WebSocketInit().Wait();
            
        }
        public MasudaBot(int appId, string appKey, string token, BotType botType, int shardId = -1)
        {
            BotSetting botSetting = new BotSetting();
            botSetting.AppId = appId;
            botSetting.AppKey = appKey;
            botSetting.Token = token;

            switch (botType)
            {
                case BotType.PublicSandBox:
                    botSetting.Intents = new Intent[] { Intent.GUILDS, Intent.AT_MESSAGES, Intent.GUILD_MEMBERS, Intent.GUILD_MESSAGE_REACTIONS };
                    botSetting.SandBox = true;
                    break;
                case BotType.Public:
                    botSetting.Intents = new Intent[] { Intent.GUILDS, Intent.AT_MESSAGES, Intent.GUILD_MEMBERS, Intent.GUILD_MESSAGE_REACTIONS };
                    break;
                case BotType.PrivateSandBox:
                    botSetting.Intents = new Intent[] { Intent.GUILDS, Intent.AT_MESSAGES, Intent.GUILD_MEMBERS, Intent.GUILD_MESSAGE_REACTIONS, Intent.NORMAL_MESSAGES };
                    botSetting.SandBox = true;
                    break;
                case BotType.Private:
                    botSetting.Intents = new Intent[] { Intent.GUILDS, Intent.AT_MESSAGES, Intent.GUILD_MEMBERS, Intent.GUILD_MESSAGE_REACTIONS, Intent.NORMAL_MESSAGES };

                    break;
                default:
                    break;
            }



            _apiKey = botSetting.AppKey;
            _token = botSetting.Token;
            _appId = botSetting.AppId;
            _log = botSetting.Log;
            _shardId = shardId;
            //"authorization", $"Bot {_appId}.{_token}"
            _httpClient.DefaultRequestHeaders.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bot", $"{_appId}.{_token}");
            if (botSetting.SandBox)
                _testUrl = "https://sandbox.api.sgroup.qq.com";
            if (botSetting.Intents != null)
                _intents = botSetting.Intents;
            _botTask = WebSocketInit();
            //WebSocketInit().Wait();

        }
        public MasudaBot(BotSetting botSetting): this(botSetting.AppId, botSetting.AppKey, botSetting.Token, botSetting.SandBox, botSetting.ShardId, botSetting.Intents, botSetting.Log)      
        {
            //_apiKey = botSetting.AppKey;
            //_appId = botSetting.AppId;
            //_token = botSetting.Token;
            //_log = botSetting.Log;
            //_shardId = botSetting.ShardId;
            ////_intents = botSetting.Intents;
            //_httpClient.DefaultRequestHeaders.Authorization
            //    = new System.Net.Http.Headers.AuthenticationHeaderValue("Bot", $"{_appId}.{_token}");
            //if (botSetting.SandBox)
            //    _testUrl = "https://sandbox.api.sgroup.qq.com";
            //if (botSetting.Intents != null)
            //    _intents = botSetting.Intents;
            //WebSocketInit();

        }
    }
}
