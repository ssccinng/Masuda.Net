using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masuda.Net.HelpMessage
{
    public class ImageMessage: MessageBase
    {
        public string? Url { get; set; }
        public string? Path{ get; set; }
        public byte[]? Data{ get; set; }
        public ImageMessage(string url)
        {
            //Url = System.Web.HttpUtility.UrlEncode(url); ;
            Url = Uri.EscapeUriString(url); 
            //Url = Uri.UnescapeDataString(url); ;
        }

        public ImageMessage()
        {
            
        }
    }
}
