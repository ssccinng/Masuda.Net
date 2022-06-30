using System.Text.Json.Serialization;
using Masuda.Net.Models;

namespace Masuda.Net.HelpMessage;

public class ReactionsUsers
{
    /// <summary>
    /// 用户对象，参考 User，会返回 id, username, avatar
    /// </summary>
    [JsonPropertyName("users")]
    public User[] Users { get; set; }
    /// <summary>
    /// 分页参数，用于拉取下一页
    /// </summary>
    [JsonPropertyName("cookie")]
    public string Cookie { get; set; }
    /// <summary>
    /// 是否已拉取完成到最后一页，true代表完成
    /// </summary>
    [JsonPropertyName("is_end")]
    public bool IsEnd { get; set; }
}