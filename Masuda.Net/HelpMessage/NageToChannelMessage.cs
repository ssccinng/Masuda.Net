using Masuda.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masuda.Net.HelpMessage
{
    public class NageToChannelMessage: MessageBase
    {
        private string _channelId;
        public NageToChannelMessage(string channelId)
        {
            _channelId = channelId;
        }

        public NageToChannelMessage(Channel channel): this(channel.Id)
        {
        }
        public override string ToString()
        {
            return $"<#{_channelId}>";
        }
    }
}
