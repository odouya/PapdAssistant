using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    /// <summary>
    /// 检查更新
    /// </summary>
    public class PajkCheckUpdateResult
    {
        public string backupUrl { get; set; }
        public string appId { get; set; }
        public string desc { get; set; }
        public string pkgSize { get; set; }
        public string marketPkg { get; set; }
        public string forceDesc { get; set; }
        public string downloadUrl { get; set; }
        public string versionName { get; set; }
        public string channel { get; set; }
        public bool forceUpgrade { get; set; }
        public string version { get; set; }
        public string latestForceVersion { get; set; }
    }
}
