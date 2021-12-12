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
    public class AtMessage
    {
        private string _userId;
        public AtMessage(string userId)
        {
            _userId = userId;
        }
        public override string ToString()
        {
            return $"<@{_userId}>";
        }
    }
}
