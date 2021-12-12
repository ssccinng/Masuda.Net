using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masuda.Net.Models
{
    /// <summary>
    /// 标识需要设置哪些字段
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// 是否设置名称: 0-否, 1-是
        /// </summary>
        public int Name { get; set; }
        /// <summary>
        /// 是否设置颜色: 0-否, 1-是
        /// </summary>
        public int Color { get; set; }
        /// <summary>
        /// 是否设置在成员列表中单独展示: 0-否, 1-是
        /// </summary>
        public int Hoist { get; set; }
    }
    public class Info
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ARGB的HEX十六进制颜色值转换后的十进制数值
        /// </summary>
        public uint Color { get; set; }
        /// <summary>
        /// 是否在成员列表中单独展示: 0-否, 1-是
        /// </summary>
        public int Hoist { get; set; }
    }
}
