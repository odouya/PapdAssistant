using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Tool
{
    /// <summary>
    /// 游戏中心签名信息
    /// </summary>
    public class GameSignatureInfo
    {
        public string clientId;
        public string signature;
        public long timeStamp;
        public long userId;
        public string userName;
    }
}
