using System.Text.Json.Serialization;

namespace Masuda.Net.Models;

public class APIPermission
{
    /// <summary>
    /// API 接口名，例如 /guilds/{guild_id}/members/{user_id}
    /// </summary>
    [JsonPropertyName("path")]
    public string Path { get; set; }

    /// <summary>
    /// 请求方法，例如 GET
    /// </summary>
    [JsonPropertyName("method")]
    public string Method { get; set; }

    /// <summary>
    /// API 接口名称，例如 获取频道信
    /// </summary>
    [JsonPropertyName("desc")]
    public string Desc { get; set; }

    /// <summary>
    /// 授权状态，auth_stats 为 1 时已授权
    /// </summary>
    [JsonPropertyName("auth_status")]
    public int AuthStatus { get; set; }
}

/// <summary>
/// 接口权限需求对象（APIPermissionDemand）
/// </summary>
public class APIPermissionDemand
{
    /// <summary>
    /// 申请接口权限的频道 id
    /// </summary>
    [JsonPropertyName("guild_id")]
    public string GuildId { get; set; }

    /// <summary>
    /// 接口权限需求授权链接发送的子频道 id
    /// </summary>
    [JsonPropertyName("channel_id")]
    public string ChannelId { get; set; }

    /// <summary>
    /// 权限接口唯一标识
    /// </summary>
    [JsonPropertyName("api_identify")]
    public APIPermissionDemandIdentify ApiIdentify { get; set; }

    /// <summary>
    /// 接口权限链接中的接口权限描述信息
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// 接口权限链接中的机器人可使用功能的描述信息
    /// </summary>
    [JsonPropertyName("desc")]
    public string Desc { get; set; }
}

public class APIPermissionDemandIdentify
{
    /// <summary>
    /// API 接口名，例如 /guilds/{guild_id}/members/{user_id}
    /// </summary>
    [JsonPropertyName("path")]
    public string Path { get; set; }

    /// <summary>
    /// 请求方法，例如 GET
    /// </summary>
    [JsonPropertyName("method")]
    public string Method { get; set; }
}