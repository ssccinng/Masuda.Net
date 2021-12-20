using Masuda.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.Net.HelpMessage
{
    public class Links
    {
        //[JsonPropertyName("desc")]
        public string Desc { get; set; }
        //[JsonPropertyName("link")]
        public string Link { get; set; }
    }
    public class _37BigImageArk: MessageArk
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prompt">提示消息</param>
        /// <param name="metaTitle">标题</param>
        /// <param name="metaSubtitle">子标题</param>
        /// <param name="metaCover">大图，尺寸为 975*540</param>
        /// <param name="metaUrl">跳转链接</param>
        public _37BigImageArk(string prompt = null, string metaTitle = null, string metaSubtitle = null, string metaCover = null, string metaUrl = null)
        {
            TemplateId = 37;
            Kv = new List<MessageArkKv>
            {
                new MessageArkKv {Key = "#PROMPT#", value = prompt },
                new MessageArkKv {Key = "#MetaTitle#", value = metaTitle },
                new MessageArkKv {Key = "#MetaCover#", value = metaCover },
                new MessageArkKv {Key = "#MetaUrl#", value = metaUrl },
                new MessageArkKv {Key = "#MetaSubtitle#", value = metaSubtitle },
            };
        }
    }

    public class _23LinkTextArk : MessageArk
    {
        public _23LinkTextArk(string desc = null, string prompt = null, Links[] list = null)
        {
            TemplateId = 23;

            var lista = new  List<MessageArkObj>();

            foreach (var item in list)
            {
                var v = new MessageArkObj();
                v.ObjKv = new();
                v.ObjKv.Add(new MessageArkKv { Key = "desc", value = item.Desc });
                if (item.Link != null)
                {
                    v.ObjKv.Add(new MessageArkKv { Key = "link", value = item.Link });
                }
            }
            Kv = new List<MessageArkKv>
            {
                new MessageArkKv {Key = "#PROMPT#", value = prompt },
                new MessageArkKv {Key = "#DESC#", value = desc },
                new MessageArkKv {Key = "#LIST#", Obj = lista  },
            };
        }
    }

    public class _24ImgTextArk : MessageArk
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="desc"></param>
        /// <param name="prompt"></param>
        /// <param name="title"></param>
        /// <param name="metadesc"></param>
        /// <param name="img"></param>
        /// <param name="link"></param>
        /// <param name="subtitle"></param>
        public _24ImgTextArk(string desc = null, string prompt = null, string title = null, string metadesc = null, string img = null, string link = null, string subtitle = null)
        {
            TemplateId = 24;
            Kv = new List<MessageArkKv>
            {
                new MessageArkKv {Key = "#DESC#", value = desc },
                new MessageArkKv {Key = "#PROMPT#", value = prompt },
                new MessageArkKv {Key = "#TITLE#", value = title },
                new MessageArkKv {Key = "#METADESC#", value = metadesc },
                new MessageArkKv {Key = "#IMG#", value = img },
                new MessageArkKv {Key = "#LINK#", value = link },
                new MessageArkKv {Key = "#SUBTITLE#", value = subtitle },
            };
        }
    }
}
