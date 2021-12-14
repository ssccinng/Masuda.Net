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
        public override string ToString()
        {
            return Content;
        }
    }
}
