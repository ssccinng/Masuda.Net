﻿using Masuda.Net.HelpMessage;
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
    }
}
