using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.Net.Models
{
    /// <summary>
    /// 成员
    /// </summary>
    public class Member
    {
        /// <summary>
        /// 成员QQ资料
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// 成员频道昵称
        /// </summary>
        public string Nick { get; set; }
        /// <summary>
        /// 成员身份列表
        /// </summary>
        public string[] Roles { get; set; }
        /// <summary>
        /// 成员加入时间
        /// </summary>
        [JsonPropertyName("joined_at")]
        public DateTime joinedAt { get; set; }
    }

    public class MemberWithGuildID : Member
    {
        /// <summary>
        /// 频道Id
        /// </summary>
        [JsonPropertyName("guild_id")]
        public string GuildId { get; set; }
    }
}
