using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.Net.Models
{
    public class MessageReaction
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
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
        /// 表态对象
        /// </summary>
        [JsonPropertyName("target")]
        public ReactionTarget Target { get; set; }
        /// <summary>
        /// 表情
        /// </summary>
        [JsonPropertyName("emoji")]
        public Emoji Emoji { get; set; }

    }
    public class ReactionTarget
    {
        /// <summary>
        /// 表态对象ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>
        /// 表态对象类型
        /// </summary>
        [JsonPropertyName("type")]
        public ReactionTargetType Type { get; set; }
    }

    public enum ReactionTargetType
    {
        Message,
        Post,
        Comment,
        Reply,
    }
}
