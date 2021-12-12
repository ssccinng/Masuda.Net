using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masuda.Net.Models
{
    /// <summary>
    /// 权限
    /// </summary>
    public enum Intent
    {
        GUILDS = 1 << 0,
        GUILD_MEMBERS = 1 << 1,
        GUILD_MESSAGE_REACTIONS = 1 << 10,
        DIRECT_MESSAGE = 1 << 12,
        AUDIO_ACTION = 1 << 29,
        AT_MESSAGES = 1 << 30,
    }
}
