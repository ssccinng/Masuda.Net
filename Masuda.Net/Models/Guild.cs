using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Masuda.Net.Models
{
    public class Guild
    {
        /// <summary>
        /// 频道Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 频道名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 频道Icon路径
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 频道拥有者Id
        /// </summary>
        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; }
        /// <summary>
        /// 当前人是否为频道创建人
        /// </summary>
        public bool Owner { get; set; }
        /// <summary>
        /// 成员总数
        /// </summary>
        [JsonPropertyName("member_count")]
        public int MemberCount { get; set; }
        /// <summary>
        /// 最大成员数
        /// </summary>
        [JsonPropertyName("max_members")]
        public int MaxMember { get; set; }
        /// <summary>
        /// 频道描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 加入时间
        /// </summary>
        [JsonPropertyName("joined_at")]
        public string JoinedAt { get; set; }
        // 未必要 频道身份组
        [NonSerialized]
        public List<Role> Roles;
    }
}
