using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    /// <summary>
    /// 状态信息
    /// </summary>
    public class StateInfo
    {
        public long systime { get; set; }
        public StateInfoItem[] stateList { get; set; }
        public string data { get; set; }
        public long code { get; set; }
        public string cid { get; set; }

        /// <summary>
        /// 状态编码字典
        /// </summary>
        public static Dictionary<long, string> StateCodeDic;
 
        /// <summary>
        /// 静态构造函数
        /// </summary>
        static StateInfo()
        {
            StateCodeDic = new Dictionary<long, string>();
            StateCodeDic.Add(-380, "用户有被锁定的风险！");//RISK_USER_LOCKED
            StateCodeDic.Add(-340, "账号已经在设备上退出！");//NO_ACTIVE_DEVICE
            StateCodeDic.Add(-320, "没有受信用设备！");//NO_TRUSTED_DEVICE
            StateCodeDic.Add(-180, "签名错误！");//SIGNATURE_ERROR
            StateCodeDic.Add(-370, "用户已经被锁定！");//USER_LOCKED
            StateCodeDic.Add(-360, "TOKEN错误！");//TOKEN_ERROR
            StateCodeDic.Add(-300, "TOKEN已过期！");//TOKEN_EXPIRE
            StateCodeDic.Add(-200, "POSTDATA参数无效！");
            StateCodeDic.Add(0, "成功！");//SUCCESS
        }

        /// <summary>
        /// 获取错误信息
        /// </summary>
        /// <returns></returns>
        public string GetCodeInfo()
        {
            if (StateCodeDic.Keys.Contains(this.code))
            {
                return StateCodeDic[this.code];
            }
            else
            {
                return "未知父错误码：" + this.code;
            }
        }
    }
}
