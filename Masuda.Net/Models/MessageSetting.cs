using System;
using System.Text.Json.Serialization;

namespace Masuda.Net.Models;

public class MessageSetting
{
    /// <summary>
    /// 是否允许创建私信
    /// </summary>
    [JsonPropertyName("disable_create_dm")]
    public string DisableCreateDm { get; set; }
    /// <summary>
    /// 是否允许发主动消息
    /// </summary>
    [JsonPropertyName("disable_push_msg")]
    public string DisablePushMsg { get; set; }
    /// <summary>
    /// 子频道 id 数组
    /// </summary>
    [JsonPropertyName("channel_ids")]
    public string[] ChannelIds { get; set; }
    /// <summary>
    /// 每个子频道允许主动推送消息最大消息条数
    /// </summary>
    [JsonPropertyName("channel_push_max_num")]
    public uint ChannelPushMaxNum { get; set; }
}