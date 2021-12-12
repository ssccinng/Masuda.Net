using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.Net.Models
{
    /// <summary>
    /// 公告
    /// </summary>
    public class Announces
    {
        /// <summary>
        /// 频道Id
        /// </summary>
        [JsonPropertyName("guild_id")]
        public string GuildId { get; set; }

        /// <summary>
        /// 子频道Id
        /// </summary>
        [JsonPropertyName("channel_id")]
        public string ChannelId { get; set; }

        /// <summary>
        /// 消息Id
        /// </summary>
        [JsonPropertyName("message_id")]
        public string MessageId { get; set; }
    }
}
