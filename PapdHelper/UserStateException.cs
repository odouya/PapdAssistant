using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PapdLib.Info;

namespace PapdLib
{
    /// <summary>
    /// 用户状态异常
    /// </summary>
    public class UserStateException : Exception
    {
        public StateInfo StateInfo;

        public UserStateException(StateInfo info) 
            : base(info==null?string.Empty:info.GetCodeInfo())
        {
        }
    }
}
