using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.Net.Models
{
    /// <summary>
    /// 子频道类型
    /// </summary>
    public enum ChannelType
    {
        /// <summary>
        /// 文字子频道
        /// </summary>
        TextChannel = 0,
        Pre1 = 1,
        /// <summary>
        /// 语音子频道
        /// </summary>
        VoiceChannel = 2,
        Pre2 = 3,
        /// <summary>
        /// 子频道分组
        /// </summary>
        ChannelSubGroup = 4,
        Pre3 = 5,
        Pre4 = 6,
        Pre5 = 7,
        /// <summary>
        /// 直播子频道
        /// </summary>
        LiveChannel = 10005,
        /// <summary>
        /// 应用子频道
        /// </summary>
        AppChannel = 10006,
        /// <summary>
        /// 论坛子频道
        /// </summary>
        ForumChannel = 10007,
        Unknown1 = 10008,
        Unknown2 = 10009,
        Unknown3 = 10010,
        Unknown4 = 10011,
        Unknown5 = 10012,
        Unknown6 = 10013,
        Unknown7 = 10014,
    }
    /// <summary>
    /// 子频道二级分类(目前只有文字子频道有)
    /// </summary>
    public enum ChannelSubType
    {
        /// <summary>
        /// 闲聊
        /// </summary>
        XianLiao,
        /// <summary>
        /// 公告
        /// </summary>
        GongGao,
        /// <summary>
        /// 攻略
        /// </summary>
        GongLue,
        /// <summary>
        /// 开黑
        /// </summary>
        KaiHei,
    }
    /// <summary>
    /// 子频道
    /// </summary>
    public class Channel
    {
        /// <summary>
        /// 子频道Id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>
        /// 频道Id
        /// </summary>
        [JsonPropertyName("guild_id")]
        public string GuildId { get; set; }
        /// <summary>
        /// 子频道名称
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// 频道类型
        /// </summary>
        [JsonPropertyName("type")]
        public ChannelType Type { get; set; }
        /// <summary>
        /// 子频道二级类型
        /// </summary>
        [JsonPropertyName("sub_type")]
        public ChannelSubType SubType { get; set; }
        /// <summary>
        /// 位置，且不与其他子频道重复
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// 分组Id
        /// </summary>
        [JsonPropertyName("parent_id")]
        public string ParentId { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; }


    }
}
