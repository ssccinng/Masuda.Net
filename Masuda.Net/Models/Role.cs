using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.Net.Models
{
    /// <summary>
    /// 频道身份组
    /// </summary>
    public class Role
    {

        /// <summary>
        /// 身份组Id 默认(1: 全体成员, 2: 管理员, 4: 群主/创建者, 5: 子频道管理员)
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 身份名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ARGB的HEX十六进制颜色值转换后的十进制数值
        /// </summary>
        public uint Color   { get; set; }
        /// <summary>
        /// 是否在成员列表中单独展示: 0-否, 1-是
        /// </summary>
        public uint Hoist { get; set; }
        /// <summary>
        /// 人数
        /// </summary>
        public uint Number { get; set; }
        /// <summary>
        /// 成员上限
        /// </summary>
        [JsonPropertyName("member_limit")]
        public uint MemberLimit { get; set; }
    }
}
