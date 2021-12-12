using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.Net.Models
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 用户头像地址
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 特殊关联应用OpenId(需申请)
        /// </summary>
        [JsonPropertyName("union_openid")]
        public string UnionOpenid { get; set; }
        /// <summary>
        /// 机器人关联的互联应用的用户信息(需申请)
        /// </summary>
        [JsonPropertyName("union_user_account")]
        public string UnionUserAccount { get; set; }

    }
}
