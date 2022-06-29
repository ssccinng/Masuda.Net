using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.Net.Models
{
    public class ChannelPermissions
    {
        /// <summary>
        /// 子频道Id
        /// </summary>
        [JsonPropertyName("channel_id")]
        public string ChannelId { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        /// <summary>
        /// 权限是QQ频道管理频道成员的一种方式，管理员可以对不同的人、不同的子频道设置特定的权限。用户的权限包括个人权限和身份组权限两部分，最终生效是取两种权限的并集。
        /// 权限使用位图表示，传递时序列化为十进制数值字符串。如权限值为0x6FFF，会被序列化为十进制"28671"
        /// </summary>
        [JsonPropertyName("permissions")]
        public string Permissions { get; set; }

        public List<Permissions> PermissionsArray
        {
            get
            {
                List<Permissions> list = new List<Permissions>();
                long ps = long.Parse(Permissions);
                //int idx = 0;
                //while (ps > 0)
                //{
                //    if ((ps & 1) == 1)
                //    {
                //        list.Add((Permissions)(1 << idx));
                //    }
                //    idx++;
                //}
                foreach (Permissions e in Enum.GetValues(typeof(Permissions)))
                {
                    if ((ps & (long)e) != 0)
                    {
                        list.Add(e);
                    }
                }

                return list;
            }
            set
            {
                long res = 0;
                foreach (Permissions permission in value)
                {
                    res += (long)permission;
                }
                Permissions = res.ToString();
            }
        }
    }

    public enum Permissions
    {
        Look = 1,
        Manager = 2,
        Say = 4,
        Live = 8,
    }
}
