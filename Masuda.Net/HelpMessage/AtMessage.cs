using Masuda.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masuda.Net.HelpMessage
{
    /// <summary>
    /// 艾特用户的消息
    /// </summary>
    public class AtMessage: MessageBase
    {
        private string _userId;
        public AtMessage(string userId)
        {
            _userId = userId;
        }

        public AtMessage(Message message): this(message.Author.Id)
        {
        }
        public AtMessage(User user) : this(user.Id)
        {
        }
        public AtMessage(Member member) : this(member.User.Id)
        {
        }


        public override string ToString()
        {
            return $"<@!{_userId}> ";
            //return $"<@!{_userId}>";
        }
    }
}
