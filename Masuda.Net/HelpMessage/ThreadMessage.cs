using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.Net.HelpMessage
{
    /// <summary>
    /// 获取帖子结果
    /// </summary>
    public partial class GetThreadResult
    {
        [JsonPropertyName("threads")]
        public Thread[] Threads { get; set; }

        [JsonPropertyName("is_finish")]
        public long IsFinish { get; set; }
    }

    public partial class GetThreadInfoResult
    {
        [JsonPropertyName("thread")]
        public Thread Thread { get; set; }
    }


    public partial class Thread
    {
        [JsonPropertyName("guild_id")]
        public string GuildId { get; set; }

        [JsonPropertyName("channel_id")]
        public long ChannelId { get; set; }

        [JsonPropertyName("author_id")]
        public string AuthorId { get; set; }

        [JsonPropertyName("thread_info")]
        public ThreadInfo ThreadInfo { get; set; }
    }

    public partial class ThreadInfo
    {
        [JsonPropertyName("thread_id")]
        public string ThreadId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("date_time")]
        public DateTimeOffset DateTime { get; set; }
    }


    public enum ThreadFormat
    {
        FORMAT_TEXT = 1,//	普通文本
        FORMAT_HTML = 2,//		HTML
        FORMAT_MARKDOWN = 3,//	Markdown
        FORMAT_JSON = 4,//	JSON（content参数可参照RichText结构）
    }

    /// <summary>
    /// 发帖消息结构体
    /// </summary>
    public partial class PostThread
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("format")]
        public ThreadFormat Format { get; set; }
    }

    /// <summary>
    /// 发帖消息结果
    /// </summary>
    public partial class PostThreadResult
    {
        [JsonPropertyName("task_id")]
        public string TaskId { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        [JsonPropertyName("create_time")]
        public long CreateTime { get; set; }
    
    }


}
