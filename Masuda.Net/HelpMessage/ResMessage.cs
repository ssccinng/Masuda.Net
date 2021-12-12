using Masuda.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.Net.HelpMessage
{
    public class CreateRoleRes
    {
        /// <summary>
        /// 身份组ID
        /// </summary>
        [JsonPropertyName("role_id")]
        public string RoleId { get; set; }
        /// <summary>
        /// 所创建的频道身份组对象
        /// </summary>
        [JsonPropertyName("role")]
        public Role Role { get; set; }
    }

    public class ModifyRolesRes
    {
        /// <summary>
        /// 频道Id
        /// </summary>
        [JsonPropertyName("guild_id")]
        public string GuildId { get; set; }
        /// <summary>
        /// 身份组ID
        /// </summary>
        [JsonPropertyName("role_id")]
        public string RoleId { get; set; }
        /// <summary>
        /// 所创建的频道身份组对象
        /// </summary>
        [JsonPropertyName("role")]
        public Role Role { get; set; }
    }

    public class WssWithSharedRes
    {
        /// <summary>
        /// Wss链接
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }
        /// <summary>
        /// 建议分片数
        /// </summary>
        [JsonPropertyName("shards")]
        public int Shards   { get; set; }
        /// <summary>
        /// 创建Session限制信息
        /// </summary>
        [JsonPropertyName("session_start_limit")]
        public SessionStartLimit SessionStartLimit { get; set; }

    }

    public class SessionStartLimit
    {
        /// <summary>
        /// 每 24 小时可创建 Session 数
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }
        /// <summary>
        /// 目前还可以创建的 Session 数
        /// </summary>
        [JsonPropertyName("remaining")]
        public int Remaining { get; set; }
        /// <summary>
        /// 重置计数的剩余时间(ms)
        /// </summary>
        [JsonPropertyName("reset_after")]
        public int ResetAfter { get; set; }
        /// <summary>
        /// 每 5s 可以创建的 Session 数
        /// </summary>
        [JsonPropertyName("max_concurrency")]
        public int MaxConcurrency { get; set; }
    }
}
