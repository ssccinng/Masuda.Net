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
        /// <summary>
        /// 需要申请私域 非at消息
        /// </summary>
        NORMAL_MESSAGES = 1 << 9,
        GUILD_MESSAGE_REACTIONS = 1 << 10,
        DIRECT_MESSAGE = 1 << 12,
        FORUM_EVENT = 1 << 28,
        AUDIO_ACTION = 1 << 29,
        AT_MESSAGES = 1 << 30,
    }

    public enum ActionType
    {
        GUILD_CREATE,
        GUILD_UPDATE,
        GUILD_DELETE,
        CHANNEL_CREATE,
        CHANNEL_UPDATE,
        CHANNEL_DELETE,
        GUILD_MEMBER_ADD,
        GUILD_MEMBER_UPDATE,
        GUILD_MEMBER_REMOVE,
        MESSAGE_REACTION_ADD,
        MESSAGE_REACTION_REMOVE,
        DIRECT_MESSAGE_CREATE,
        AUDIO_START,
        AUDIO_FINISH,
        AUDIO_OFF_MIC,
        AT_MESSAGE_CREATE,
        MESSAGE_CREATE,
    }
}
