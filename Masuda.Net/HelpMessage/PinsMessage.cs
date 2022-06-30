using Masuda.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.Net.HelpMessage
{
    public class PinsMessageResult
    {

        [JsonPropertyName("guild_id")]
        public string GuildId { get; set; }

        [JsonPropertyName("channel_id")]
        public string ChannelId { get; set; }

        [JsonPropertyName("message_ids")]
        public string[] MessageIds { get; set; }
    }
}
