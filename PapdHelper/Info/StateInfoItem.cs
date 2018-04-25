using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    /// <summary>
    /// 子状态信息
    /// </summary>
    public class StateInfoItem
    {
        /// <summary>
        /// 子状态长度
        /// </summary>
        public int length { get; set; }

        /// <summary>
        /// 子状态编码
        /// </summary>
        public long code { get; set; }

        /// <summary>
        /// 子状态信息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 子状态编码字典
        /// </summary>
        public static Dictionary<long, string> StateItemCodeDic; 

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static StateInfoItem()
        {
            StateItemCodeDic = new Dictionary<long, string>();
            StateItemCodeDic.Add(18018806,"库存不足啦！");
            StateItemCodeDic.Add(18018800, "验证码错误！");
            StateItemCodeDic.Add(-140, "参数错误！");
            StateItemCodeDic.Add(-100, "网络异常！");
            StateItemCodeDic.Add(18002000 , "系统繁忙，请稍后重试！");
			StateItemCodeDic.Add(18002005 , "商品库存不足");
			StateItemCodeDic.Add(18002001 , "系统繁忙，请稍后重试！");
			StateItemCodeDic.Add(18002002 , "发票类型错误");
			StateItemCodeDic.Add(18002003 , "系统繁忙，请稍后重试！");
			StateItemCodeDic.Add(18002004 , "根据地址ID获取地址错误");
			StateItemCodeDic.Add(18002006 , "系统繁忙，请稍后重试！");
			StateItemCodeDic.Add(18002010 , "系统繁忙，请稍后重试！");
            StateItemCodeDic.Add(38000001, "系统繁忙，请稍后重试！");
			StateItemCodeDic.Add(38000002 , "系统繁忙，请稍后重试！");
			StateItemCodeDic.Add(38000007 , "商品库存不足！");
			StateItemCodeDic.Add(38000014 , "无法从地址库获取到您的地址，请切换地址后重试！");
			StateItemCodeDic.Add(38000020 , "很抱歉，没有匹配到适合的商家，请切换地址后重试！");
			StateItemCodeDic.Add(38000021 , "很抱歉，没有匹配到适合的商家，请切换地址后重试！");
			StateItemCodeDic.Add(38000024 , "很抱歉，没有匹配到适合的商家，请切换地址后重试！");
			StateItemCodeDic.Add(38000034 , "很抱歉，没有匹配到适合的商家，请切换地址后重试！");
			StateItemCodeDic.Add(38000032 , "很抱歉，您的地址不在配送范围内，请切换地址后重试！");
            StateItemCodeDic.Add(42000007, "添加地址失败");
            StateItemCodeDic.Add(42000012, "亲，您最多能保存20个地址！");
            StateItemCodeDic.Add(38000042, "您近期已兑换过好礼，下周再来，奖品更丰富哦~");
            
            // 好友邀请
            StateItemCodeDic.Add(22000207, "不能重复提醒！");
            StateItemCodeDic.Add(22000100, "邀请码不合法！");
            StateItemCodeDic.Add(22000201, "老用户不能领取！");
            StateItemCodeDic.Add(22000202, "不能领取自己的礼包！");
            StateItemCodeDic.Add(22000203, "不能被重复邀请！");
            StateItemCodeDic.Add(22000204, "活动不在有效期或已下线！");

            // 领取健康金
            StateItemCodeDic.Add(22004001, "好友奖励未生成,稍后再来");
            StateItemCodeDic.Add(22004002, "来晚了");
            StateItemCodeDic.Add(22004003, "每天只能抢5次健康金，明天再来吧");

            StateItemCodeDic.Add(22000051, "已达到最大抽奖次数");

            StateItemCodeDic.Add(38000012, "商品已下架");
            StateItemCodeDic.Add(38000046, "目前兑换过于火爆,请稍后再来");
            StateItemCodeDic.Add(50010010, "已抢光");
            StateItemCodeDic.Add(50111011, "步数不足");
        }

        /// <summary>
        /// 获取状态信息字符串
        /// </summary>
        /// <returns></returns>
        public string GetCodeInfo()
        {
            if (StateItemCodeDic.Keys.Contains(this.code))
            {
                return StateItemCodeDic[this.code] + "(" + msg + ")";
            }
            else
            {
                throw new Exception("未知子错误码：" + this.code + "," + this.msg);
            }
        }
    }

}
