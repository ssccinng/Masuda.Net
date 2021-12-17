using Masuda.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masuda.Net.HelpMessage
{
    public class PlainMessage: MessageBase
    {
        public PlainMessage (string content)
        {
            Content = content;
        }

        public PlainMessage(Message message): this(message.Content)
        {
        }
        public override string ToString()
        {
            return Content;
        }
    }
}
