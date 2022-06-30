using Masuda.Net.HelpMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.Net.Models
{
    public class Message
    {
        /// <summary>
        /// 消息Id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>
        /// 频道Id
        /// </summary>
        [JsonPropertyName("guild_id")]
        public string GuildId { get; set; }

        /// <summary>
        /// 子频道Id
        /// </summary>
        [JsonPropertyName("channel_id")]
        public string ChannelId { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }
        /// <summary>
        /// 消息创建时间
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// 消息编辑时间
        /// </summary>
        [JsonPropertyName("edited_timestamp")]
        public DateTime EditedTimestamp { get; set; }
        /// <summary>
        /// 是否是At全体消息
        /// </summary>
        [JsonPropertyName("mention_everyone")]
        public bool MentionEveryone { get; set; }

        /// <summary>
        /// 消息创建者
        /// </summary>
        [JsonPropertyName("author")]
        public User Author { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        [JsonPropertyName("attachments")]
        public MessageAttachment[] Attachments { get; set; }
        /// <summary>
        /// embed
        /// </summary>
        [JsonPropertyName("embeds")]
        public MessageEmbed[] Embeds { get; set; }
        /// <summary>
        /// 消息中@的人
        /// </summary>
        [JsonPropertyName("mentions")]
        public User[] Mentions { get; set; }
        /// <summary>
        /// 消息创建者的member信息
        /// </summary>
        [JsonPropertyName("member")]
        public Member Member { get; set; }

        /// <summary>
        /// ark消息
        /// </summary>
        [JsonPropertyName("ark")]
        public MessageArk Ark { get; set; }
        /// <summary>
        /// 用于消息间的排序，seq 在同一子频道中按从先到后的顺序递增，不同的子频道之间消息无法排序。(目前只在消息事件中有值，2022年8月1日 后续废弃)
        /// </summary>
        [JsonPropertyName("seq")]
        public  int Seq { get; set; }
        /// <summary>
        /// 子频道消息 seq，用于消息间的排序，seq 在同一子频道中按从先到后的顺序递增，不同的子频道之间消息无法排序
        /// </summary>
        [JsonPropertyName("seq_in_channel")]
        public string SeqInChannel { get; set; }
        /// <summary>
        /// 引用消息对象
        /// </summary>
        [JsonPropertyName("message_reference")]
        public MessageReference MessageReference { get; set; }
        /// <summary>
        /// 用于私信场景下识别真实的来源频道id
        /// </summary>
        [JsonPropertyName("src_guild_id")]
        public  string SrcGuildId { get; set; }
    }
    
    public class DMSMessage: Message{}
    public class MessageEmbed: MessageBase
    {
        /// <summary>
        /// 标题
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; } = "";
        /// <summary>
        /// 消息弹窗内容
        /// </summary>
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; } = "";
        /// <summary>
        /// 缩略图
        /// </summary>
        [JsonPropertyName("thumbnail")]
        public MessageEmbedThumbnail Thumbnail { get; set; }
        /// <summary>
        /// 消息创建时间
        /// </summary>
        [JsonPropertyName("fields")]
        public MessageEmbedField[] Fields { get; set; }
    }

    public class MessageEmbedThumbnail
    {
        /// <summary>
        /// 图片地址
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class MessageEmbedField
    {
        /// <summary>
        /// 字段名
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class MessageAttachment
    {
        /// <summary>
        /// 下载地址
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class MessageArk: MessageBase
    {
        /// <summary>
        /// ark模板Id(需要申请)
        /// </summary>
        [JsonPropertyName("template_id")]
        public int TemplateId { get; set; }
        /// <summary>
        /// kv值列表
        /// </summary>
        [JsonPropertyName("kv")]
        public List<MessageArkKv> Kv { get; set; }
    }
    public class MessageArkKv
    {
        /// <summary>
        /// key
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }
        /// <summary>
        /// value
        /// </summary>
        [JsonPropertyName("value")]
        public string value { get; set; }
        /// <summary>
        /// ark obj类型的列表
        /// </summary>
        [JsonPropertyName("obj")]
        public List<MessageArkObj> Obj { get; set; }
    }
    public class MessageArkObj
    {
        [JsonPropertyName("obj_kv")]
        public List<MessageArkKv> ObjKv { get; set; }
    }
    public class MessageArkObjKv
    {
        /// <summary>
        /// key
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }
        /// <summary>
        /// value
        /// </summary>
        [JsonPropertyName("value")]
        public string value { get; set; }

    }
    public class MessageSend
    {
        [JsonPropertyName("content")]
        public string Content { get; set; }
        /// <summary>
        /// 嵌入消息
        /// </summary>
        [JsonPropertyName("embed")]
        public MessageEmbed Embed { get; set; }
        /// <summary>
        /// 模板消息
        /// </summary>
        [JsonPropertyName("ark")]
        public MessageArk Ark { get; set; }
        /// <summary>
        /// 图片url地址
        /// </summary>
        [JsonPropertyName("image")]
        public string Image { get; set; }
        /// <summary>
        /// 本地图片
        /// </summary>
        [JsonPropertyName("file_image")]
        public byte[] FileImage { get; set; }
        /// <summary>
        /// 消息id
        /// </summary>
        [JsonPropertyName("msg_id")]
        public string MsgId { get; set; }
        /// <summary>
        /// 选填，要回复的事件id, 在各事件对象中获取。
        /// </summary>
        [JsonPropertyName("event_id")]
        public string? EventId { get; set; }
        /// <summary>
        /// 选填，markdown 消息
        /// </summary>
        [JsonPropertyName("markdown")]
        public  MessageMarkdown Markdown { get; set; }
    }

    public class MessageReference
    {
        /// <summary>
        /// 需要引用回复的消息 id
        /// </summary>
        [JsonPropertyName("message_id")]
        public string MessageId { get; set; }
        /// <summary>
        /// 是否忽略获取引用消息详情错误，默认否
        /// </summary>
        [JsonPropertyName("ignore_get_message_error")]
        public bool IgnoreGetMessageError { get; set; }
    }

    public class MessageMarkdown: MessageBase
    {
        /// <summary>
        /// markdown 模板 id
        /// </summary>
        [JsonPropertyName("template_id")]
        public  int TemplateId { get; set; }
        /// <summary>
        /// markdown 模板模板参数
        /// </summary>
        [JsonPropertyName("params")]
        public MessageMarkdownParams @params { get; set; }
        /// <summary>
        /// 原生 markdown 内容,与 template_id 和 params参数互斥,参数都传值将报错。
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }

    public class MessageMarkdownParams
    {
        /// <summary>
        /// markdown 模版 key
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }
        /// <summary>
        /// markdown 模版 key 对应的 values ，列表长度大小为 1 代表单 value 值，长度大于1则为列表类型的参数 values 传参数
        /// </summary>
        [JsonPropertyName("values")]
        public string[] Values { get; set; }
    }

    public class MessageDelete
    {
        /// <summary>
        /// 被删除的消息内容
        /// </summary>
        [JsonPropertyName("message")]
        public Message Message { get; set; }
        /// <summary>
        /// 执行删除操作的用户
        /// </summary>
        [JsonPropertyName("op_user")]
        public User OpUser { get; set; }
    }

    public class MessageKeyboard
    {
        /// <summary>
        /// keyboard 模板 id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>
        /// 自定义 keyboard 内容,与 id 参数互斥,参数都传值将报错
        /// </summary>
        [JsonPropertyName("content")]
        public object Content { get; set; } 
    }
}
