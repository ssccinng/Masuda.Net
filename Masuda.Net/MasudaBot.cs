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
    public partial class MasudaBot
    {
        private HttpClient _httpClient = new();
        private int _appId;
        private string _apiKey;
        private string _token;
        //private string _testUrl = "https://sandbox.api.sgroup.qq.com";
        private string _testUrl = "https://api.sgroup.qq.com";
        private int _heartbeatInterval = 45000;
        private CancellationTokenSource _cts = new CancellationTokenSource(35000);
        protected ClientWebSocket _webSocket = new();
        private int _lastS = 1;
        private int _shardCnt = 1;
        private int _shardId = -1;
        /// <summary>
        /// 心跳计时器
        /// </summary>
        private Timer _timer;
        private string _sessionId = null;
        private Intent[] _intents = new [] {Intent.AT_MESSAGES, Intent.GUILDS, Intent.GUILD_MEMBERS};

        public event Action<MasudaBot, Message, ActionType> AtMessageAction;
        public event Action<MasudaBot, Message, ActionType> NormalMessageAction;
        public event Action<MasudaBot, AudioAction, ActionType> AudioAction;
        public event Action<MasudaBot, Message, ActionType> DircetAction;
        public event Action<MasudaBot, MessageReaction, ActionType> GuildMessageReAction;
        public event Action<MasudaBot, MemberWithGuildID, ActionType> GuildMembersAction;
        public event Action<MasudaBot, Guild, ActionType> GuildAction;
        public event Action<MasudaBot, Channel, ActionType> ChannelAction;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appKey"></param>
        /// <param name="token"></param>
        /// <param name="sendbox"></param>
        /// <param name="shardId">不给则默认全接受</param>
        /// <param name=""></param>
        public MasudaBot(int appId, string appKey, string token, bool sendbox = false, int shardId = 0, Intent[] intents = null)
        {
            _apiKey = appKey;
            _token = token;
            _appId = appId;
            //"authorization", $"Bot {_appId}.{_token}"
            _httpClient.DefaultRequestHeaders.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bot",$"{_appId}.{_token}");
            if (sendbox)
                _testUrl = "https://sandbox.api.sgroup.qq.com";
            if (intents != null)
                _intents = intents;
            WebSocketInit();
            //WebSocketInit().Wait();
            
        }
    }
}
