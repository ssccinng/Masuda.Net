using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.Net.Models
{
    public enum RemindType
    {
        None,
        OnStart,
        Before5Min,
        Before15Min,
        Before30Min,
        Before60Min,
    }
    /// <summary>
    /// 日程
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// 日程 id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>
        /// 日程 名称
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// 日程描述
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
        /// <summary>
        /// 日程开始时间戳(ms)
        /// </summary>
        [JsonPropertyName("start_timestamp")]
        public string StartTimestamp { get; set; }
        /// <summary>
        /// 日程结束时间戳(ms)
        /// </summary>
        [JsonPropertyName("end_timestamp")]
        public string EndTimestamp { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        [JsonPropertyName("creator")]
        public Member Creator { get; set; }
        /// <summary>
        /// 日程开始时跳转到的子频道 id
        /// </summary>
        [JsonPropertyName("jump_channel_id")]
        public string JumpChannelId { get; set; }
        /// <summary>
        /// 日程提醒类型
        /// </summary>
        [JsonPropertyName("remind_type")]
        public string RemindType { get; set; }
        //public RemindType RemindType { get; set; }
    }
}
