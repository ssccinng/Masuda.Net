using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.Net.Models
{
    public class DMS
    {
        /// <summary>
        /// 私信会话关联的频道 id
        /// </summary>
        [JsonPropertyName("guild_id")]
        public string GuildId { get; set; }

        /// <summary>
        /// 私信会话关联的子频道 id
        /// </summary>
        [JsonPropertyName("channel_id")]
        public string ChannelId { get; set; }

        /// <summary>
        /// 创建私信会话时间戳
        /// </summary>
        [JsonPropertyName("create_time")]
        public string CreateTime { get; set; }
    }
}
