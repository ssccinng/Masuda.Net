using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masuda.Net.Models
{
    /// <summary>
    /// 机器人配置
    /// </summary>
    public class BotSetting
    {
        public int AppId { get; set; }
        public string AppKey { get; set; }
        public string Token { get; set; }
        public bool SandBox { get; set; } = false;
        public Intent[] Intents { get; set; } = null;
        public bool Log { get; set; } = false;
        public int ShardId { get; set; } = -1;
    }
}
