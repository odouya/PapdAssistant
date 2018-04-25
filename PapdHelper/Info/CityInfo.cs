using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    /// <summary>
    /// 城市信息
    /// </summary>
    public class CityInfo
    {
        /// <summary>
        /// 城市首字母
        /// </summary>
        public string initial { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        public string cityName { get; set; }

        /// <summary>
        /// 省编码
        /// </summary>
        public string provinceCode { get; set; }

        /// <summary>
        /// 市编码
        /// </summary>
        public string cityCode { get; set; }
    }
}
