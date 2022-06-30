using System.Text.Json.Serialization;

namespace Masuda.Net.Models;

public class PinsMessage
{
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
    /// 子频道内精华消息 id 数组
    /// </summary>
    [JsonPropertyName("message_ids")]
    public string[] MessageIds { get; set; }
}