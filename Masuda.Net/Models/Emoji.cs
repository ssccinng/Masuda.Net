using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.Net.Models
{
    
    public enum EmojiType
    {
        Default = 1,
        Emoji = 2,
    }
    /// <summary>
    /// 表情
    /// </summary>
    public class Emoji
    {
        /// <summary>
        /// 表情 id 系统表情使用数字为ID，emoji使用emoji本身为id，参考 EmojiType 列表
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>
        /// 表情类型
        /// </summary>
        [JsonPropertyName("type")]
        public EmojiType Type { get; set; }

        public override string ToString()
        {
            if (Type == EmojiType.Default)
            {
                return $"<emoji:{Id}>";
            }
            else
            {
                return Id;
            }
        }

        
    }
}
