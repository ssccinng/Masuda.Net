using Masuda.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
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
        /// <summary>
        /// 心跳计时器
        /// </summary>
        private Timer _timer;
        private string _sessionId = null;
        public event Action<MasudaBot, Message> AtMessageAction;
        public event Action<MasudaBot, AudioAction> AudioAction;
        public event Action<MasudaBot, Message> DircetAction;
        public event Action<MasudaBot, Message> GuildMessageReAction;
        public event Action<MasudaBot, MemberWithGuildID> GuildMembersAction;
        public event Action<MasudaBot, Guild> GuildAction;
        public event Action<MasudaBot, Channel> ChannelAction;
        public MasudaBot(int appId, string appKey, string token)
        {
            _apiKey = appKey;
            _token = token;
            _appId = appId;
            //"authorization", $"Bot {_appId}.{_token}"
            _httpClient.DefaultRequestHeaders.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bot",$"{_appId}.{_token}");

            WebSocketInit();
            //WebSocketInit().Wait();
            
        }
    }
}
