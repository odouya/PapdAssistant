using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib.Info
{
    public class RankingInfo
    {
        //是否有下一页（不准确）
        public bool hasNext;
        //当前页
        public int pageNo;
        //排名日期
        public string rankingDay;
        //我的排名信息
        public RankingInfoLite myRankingInfo;
        //其他用户排名信息
        public RankingInfoLite[] userRankingList = new RankingInfoLite[0];
        //是否为最新数据
        public bool isNewest;
    }

    public class GrabGoldInfo
    {
        //是否有下一页（不准确）
        public bool hasNext;
        //当前页
        public int pageNo;
        //排名日期
        public string rankingDay;
        //是否为最新数据
        public bool isNewest;
        public bool initHasNext;
        public GrabGoldInfoLite myRankingInfo;
        public GrabGoldInfoLite[] userRankingList = new GrabGoldInfoLite[0];
        public GrabGoldInfoLite[] initRankingList = new GrabGoldInfoLite[0];
        //累计已抢金额
        public string totalAngPao;
    }
}
