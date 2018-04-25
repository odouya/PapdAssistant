using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PapdLib.Info;
using System.Runtime.InteropServices;
using System.Web;
using PapdLib.Tool;
using PapdLib.Util;

namespace PapdLib
{
    public class PapdHelper
    {
        #region 字段

        public const string DEFAULT_PFX_PASSWORD = "110110";
        private const string DEFAULT_URL = "https://api.jk.cn/m.api";
        public static int DEFAULT_TIMEOUT = 15000;
        private const string DEFAULT_CONTENTTYPE = "application/x-www-form-urlencoded; charset=UTF-8";//charset很重要，特别是postdata中有中文时
        private const string DEFAULT_USERAGENT = "Mozilla/5.0 (Linux; Android 5.1; MX5 Build/LMY47I; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/44.0.2403.147 Mobile Safari/537.36 pajkCordova hybridwebview pajkAppVersion/50401";

        /// <summary>
        /// 默认页大小
        /// </summary>
        public const int DEFAULT_PAGE_SIZE = 100;

        /// <summary>
        /// 相关参考Js文件
        /// </summary>
        public static readonly string JsUrl = "http://yao-h5.s.jk.cn/app-d22bd687ac8306fee479.js";

        /// <summary>
        /// 计步器页面
        /// </summary>
        public static readonly string PedometerUrl = "http://gc.jk.cn/duojin/index.html";

        /// <summary>
        /// 夺金兑换页面
        /// </summary>
        public static readonly string ExchangeUrl = "http://gc.jk.cn/duojin/physicalLottery.html";

        /// <summary>
        /// 我的订单页面
        /// </summary>
        public static readonly string MyOrdersUrl = "http://yao-h5.s.jk.cn/home.html?app=pajk#/yao-orderlist";

        /// <summary>
        /// 邀请好友记录页面
        /// </summary>
        public static readonly string InviteeRecordsUrl = "http://gc.jk.cn/duojin/inviteRecord.html";

        /// <summary>
        /// 夺金明细页面
        /// </summary>
        public static readonly string RewardListUrl = "http://gc.jk.cn/duojin/rewardList.html";
        #endregion

        public static WebProxy Proxy;

        /// <summary>
        /// 默认_chl值
        /// </summary>
        public static readonly string Default_CHL = "360ZS";
        /// <summary>
        /// 默认_vc值
        /// </summary>
        public static readonly string Default_VC = "30803";

        /// <summary>
        /// 距离与步数的默认比例
        /// </summary>
        public static readonly double DefaultDistanceScale = 0.71482;
        /// <summary>
        /// 热量与步数的默认比例
        /// </summary>
        public static readonly double DefaultCaloryScale = 0.15015;

        #region 业务功能
        /// <summary>
        /// 领取地图宝箱
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public PajkResultList<FetchMapTreasureBoxResponse> FetchMapTrusureBox(string cookie, string boxId, string lng, string lat)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("_mt", "walkman.fetchBox4Map");
            pc.Add("boxId", boxId);
            pc.Add("longitude", lng);
            pc.Add("latitude", lat);
            pc.Add("_sm", "md5");

            string result =  GetResultInternal(pc, cookie, true);
            return JsonConvert.DeserializeObject<PajkResultList<FetchMapTreasureBoxResponse>>(result);
        }

        /// <summary>
        /// 生成地图宝箱
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public PajkResultList<GenerateMapTrusureBoxResponse> GenerateMapTrusureBox(string cookie)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("_mt", "walkman.generateUserBox");
            pc.Add("longitude", 114.48249815938064);
            pc.Add("latitude", 37.08534174656903);
            pc.Add("_sm", "md5");

            string result =  GetResultInternal(pc, cookie, true, false);
            return JsonConvert.DeserializeObject<PajkResultList<GenerateMapTrusureBoxResponse>>(result);
        }

        /// <summary>
        /// 延期金币过期时间
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public string DelayGlodExpireTime(string cookie)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("_mt", "evaluate.exerciseOfPrivilege");
            pc.Add("evaluateId", 2);
            pc.Add("_sm", "md5");

            return GetResultInternal(pc, cookie, true);
        }

        /// <summary>
        /// 查询金币过期信息
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public PajkResultList<QueryGoldExpireInfoResponse> QueryGoldExpireInfo(string cookie)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("_mt", "pointquery.queryPointPostponedInfo");
            pc.Add("_sm", "md5");

            return GetResultList<QueryGoldExpireInfoResponse>(pc, cookie, true);
        }

        /// <summary>
        /// 砸蛋
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public PajkResultList<PajkZaEggResult> ZaEgg(string cookie)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("_mt", "opm.pocketGetJanuary");
            pc.Add("_sm", "md5");
            pc.Add("_aid", "0");
            pc.Add("_vc", "40100");

            return GetResultList<PajkZaEggResult>(pc, cookie, true);
        }

        /// <summary>
        /// 获取我的宝箱详情
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public PajkResultList<PajkGetMyBoxDetail> GetMyBoxDetail(string cookie)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("_mt", "promotion.getBoxDetail");
            pc.Add("_sm", "md5");

            return GetResultList<PajkGetMyBoxDetail>(pc, cookie, true);
        }

        /// <summary>
        /// 获取我的宝箱个数
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public PajkResultList<PajkGetMyBoxNum> FetchMyBoxNum(string cookie)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("_mt", "promotion.getAccount");
            pc.Add("_sm", "md5");

            return GetResultList<PajkGetMyBoxNum>(pc, cookie, true);
        }

        /// <summary>
        /// 通过看直播获取宝箱
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public PajkResultList<PajkFetchBoxResult> FetchBoxByVideo(string cookie)
        {
            return FetchBox4BizInternal(cookie, "webcast_100");
        }

        /// <summary>
        /// 通过邀请好友获取宝箱
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public PajkResultList<PajkFetchBoxResult> FetchBoxByInviteFriend(string cookie)
        {
            return FetchBox4BizInternal(cookie, "duojin_400");
        }

        /// <summary>
        /// 通过逛商场获取宝箱
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public PajkResultList<PajkFetchBoxResult> FetchBoxByWalkMall(string cookie)
        {
            return FetchBox4BizInternal(cookie, "mall_201");
        }

        /// <summary>
        /// 通过分享头条获取宝箱
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public PajkResultList<PajkFetchBoxResult> FetchBoxByShareReading(string cookie)
        {
            return FetchBox4BizInternal(cookie, "headline_500");
        }

        /// <summary>
        /// 获取宝箱
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        private PajkResultList<PajkFetchBoxResult> FetchBox4BizInternal(string cookie, string code)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("code", code);
            pc.Add("_st", ConvertToUnixTimeInMilli(DateTime.Now));
            pc.Add("_mt", "promotion.fetchBox4Biz");
            pc.Add("_sm", "md5");

            return GetResultList<PajkFetchBoxResult>(pc, cookie, true);
        }

        /// <summary>
        /// 获取所有礼品信息
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public PajkResultList<PajkGetDepotResult> GetDepot(string cookie)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("pageNo",1);
            pc.Add("pageSize",50);
            pc.Add("_mt","promotion.getDepot");
            pc.Add("_sm","md5");

            return GetResultList<PajkGetDepotResult>(pc, cookie, true);
        }

        public PajkResultList<T> GetResultList<T>(ParaCollection pc, string cookie, bool useCookieToCalcSig) where T:new()
        {
            string respStr = GetResultInternal(pc, cookie, useCookieToCalcSig);
            return JsonConvert.DeserializeObject<PajkResultList<T>>(respStr);
        }

        public PajkResult<T> GetResultObject<T>(ParaCollection pc, string cookie, bool useCookieToCalcSig) where T : new()
        {
            string respStr = GetResultInternal(pc, cookie, useCookieToCalcSig);
            return JsonConvert.DeserializeObject<PajkResult<T>>(respStr);
        }

        private string GetResultInternal(ParaCollection pc, string cookie, bool useCookieToCalcSig)
        {
            return GetResultInternal(pc, cookie, useCookieToCalcSig, true);
        }

        private string GetResultInternal(ParaCollection pc, string cookie, bool useCookieToCalcSig, bool isCheckRespState)
        {
            if (!pc.ContainsKey("_sig"))
                pc.Add("_sig", CalcSig(pc.ToString(), useCookieToCalcSig ? cookie : null));
            string respStr = PostData(pc.ToString(), cookie);
            if (isCheckRespState)
            {
                CheckResponseState(respStr); 
            }

            return respStr;
        }

        public PajkResult<T> PostWithRsa<T>(PajkMethods memthodName,
                                    string userId,
                                    string userToken,
                                    string userCertPath) where T : new()
        {
            return PostWithRsa<T>(memthodName, userId, userToken, userCertPath, null);
        }

        public PajkResult<T> PostWithRsa<T>(PajkMethods memthodName, 
                                    string userId, 
                                    string userToken, 
                                    string userCertPath,
                                    ParaCollection extraParams) where T:new()
        {
            string privateKey, didValue;
            if (!CertificateUtil.GetPfxPrivateKeyAndDidValue(userCertPath, out privateKey, out didValue))
                return null;

            ParaCollection pc = new ParaCollection();
            pc.Add("_aid", "1");
            pc.Add("_chl", Default_CHL);
            pc.Add("_did", didValue);
            pc.Add("_ft", "json");
            pc.Add("_mt", memthodName);
            pc.Add("_sm", "rsa");
            pc.Add("_tk", userToken);
            pc.Add("_uid", userId);
            pc.Add("_vc", Default_VC);
            pc.Add(extraParams);
            pc.Add("_sig", CalcSig(pc.ToString(), null, privateKey), true);
            pc["_tk"] = HttpUtility.UrlEncode(pc["_tk"]);

            string respStr = PostData(pc.ToString());

            return JsonConvert.DeserializeObject<PajkResult<T>>(respStr);
        }

        public PajkResult<List<PajkDownloadWalkDataResult>> DownloadWalkData(
            string userId,
            string userCookieWithUserToken,
            string userCertPath)
        {
            ParaCollection epc = new ParaCollection();
            epc.Add("eDate", 0);
            epc.Add("sDate", 0);

            return PostWithRsa<List<PajkDownloadWalkDataResult>>(
                            PajkMethods.DownloadWalkData, userId,
                            CookieUtil.GetCookieValue(userCookieWithUserToken, "_tk"),
                            userCertPath,
                            epc);
        }

        /// <summary>
        /// 上传走步数据
        /// </summary>
        /// <returns></returns>
        public PajkResult<List<PajkBooleanValueResult>> UploadWalkData(
            string userId,
            string userCookieWithUserToken,
            string userCertPath,
            int stepCount)
        {
            ParaCollection epc = new ParaCollection();
            epc.Add("walkDataInfos", GenWalkDataInfosJson(stepCount), true);

            return PostWithRsa<List<PajkBooleanValueResult>>(
                            PajkMethods.UploadWalkData, userId,
                            CookieUtil.GetCookieValue(userCookieWithUserToken, "_tk"),
                            userCertPath,
                            epc);
        }

        #region 生成走步数据信息Json串
        /// <summary>
        /// 生成走步数据信息Json串
        /// </summary>
        /// <param name="steps">步数</param>
        /// <returns></returns>
        private string GenWalkDataInfosJson(int steps)
        {
            var caloryInfo = new
            {
                calories = steps * DefaultCaloryScale, //10位小数，单位：卡
                targetStepCount = 5000,
                distance = steps * DefaultDistanceScale, //7位小数，单位：米
                walkDate = DateTime.Now.ToString("yyyyMMdd"),
                stepCount = steps,
                id = 0,
                walkTime = (DateTime.UtcNow - new DateTime(1970, 1, 1)).Ticks * 1.0 / Math.Pow(10, 4) //0.1毫秒
            };
            var calories = new[] { caloryInfo };

            return JsonConvert.SerializeObject(calories);
        }
        #endregion

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="userCookieWithUserToken">cookie，包含_tk</param>
        /// <param name="userCertPath">证书文件路径</param>
        /// <returns></returns>
        public PajkResult<List<PajkBooleanValueResult>> Logout(
            string userId,
            string userCookieWithUserToken,
            string userCertPath)
        {
            return PostWithRsa<List<PajkBooleanValueResult>>(
                            PajkMethods.UserLogout, userId,
                            CookieUtil.GetCookieValue(userCookieWithUserToken, "_tk"),
                            userCertPath);
        }

        /// <summary>
        /// 抽奖
        /// </summary>
        /// <returns></returns>
        public PajkResult<List<PajkDoLotteryResult>> DoLottery(string cookie, string itemId)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("activityCode", "STEPCOUNTER_RES_LOTTERY");
            pc.Add("itemId", itemId);
            pc.Add("verifyCode", "");
            pc.Add("_mt", "promotion.stepCounterResLottery");
            pc.Add("_st", ConvertToUnixTimeInMilli(DateTime.Now));
            pc.Add("_sm", "md5");
            pc.Add("_sig", CalcSig(pc.ToString(), cookie));

            string respStr = PostData(pc.ToString(), cookie);

            CheckResponseState(respStr);

            return JsonConvert.DeserializeObject<PajkResult<List<PajkDoLotteryResult>>>(respStr);
        }

        /// <summary>
        /// 查询可抽奖的项目
        /// </summary>
        /// <returns></returns>
        public PajkResult<List<PajkPrizeInfo>> QueryPrizeList(string cookie)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("_mt", "promotion.queryPrizeList");
            pc.Add("prizeQuery", "{\"activityCode\":\"STEPCOUNTER_RES_LOTTERY\",\"activityId\":0,\"id\":0}", true);
            pc.Add("_st", ConvertToUnixTimeInMilli(DateTime.Now));
            pc.Add("_sm", "md5");
            pc.Add("_sig", CalcSig(pc.ToString(), cookie));

            string respStr = PostData(pc.ToString(), cookie);

            return JsonConvert.DeserializeObject<PajkResult<List<PajkPrizeInfo>>>(respStr);
        }

        /// <summary>
        /// QQ登录
        /// </summary>
        /// <returns></returns>
        public PajkResult<List<PajkLoginResult>> QQLogin(
            string qqAccessToken,
            string deviceToken,
            string userCertPath)
        {
            string privateKey, didValue;
            if (!CertificateUtil.GetPfxPrivateKeyAndDidValue(userCertPath, out privateKey, out didValue))
                return null;

            ParaCollection pc = new ParaCollection();
            pc.Add("_aid", "1");
            pc.Add("_chl", Default_CHL);
            pc.Add("_did", didValue);
            pc.Add("_dtk", deviceToken);
            pc.Add("_ft", "json");
            pc.Add("_mt", PajkMethods.UserQQLogin);
            pc.Add("_sm", "rsa");
            pc.Add("_vc", Default_VC);
            pc.Add("_sig", CalcSig(pc.ToString(), null, privateKey), true);
            pc["_tk"] = HttpUtility.UrlEncode(pc["_tk"]);

            string respStr = PostData(pc.ToString());

            return JsonConvert.DeserializeObject<PajkResult<List<PajkLoginResult>>>(respStr);
        }

        /// <summary>
        /// 获取UserToken和WebUserToken
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="userCookieWithUserToken">cookie，包含_tk</param>
        /// <param name="userCertPath">证书文件路径</param>
        /// <returns></returns>
        public PajkResult<List<PajkRenewTkAndWtkResult>> RenewUserToken(
            string userId,
            string userCookieWithUserToken,
            string userCertPath)
        {
            return PostWithRsa<List<PajkRenewTkAndWtkResult>>(
                            PajkMethods.UserRenewUserToken, userId,
                            CookieUtil.GetCookieValue(userCookieWithUserToken, "_tk"),
                            userCertPath);
        }

        /// <summary>
        /// 获取UserToken和WebUserToken
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="userCookieWithUserToken">cookie，包含_tk</param>
        /// <param name="userCertPath">证书文件路径</param>
        /// <returns></returns>
        public PajkResult<List<PajkRenewTkAndWtkResult>> RenewUserTokenAndWebToken(
            string userId, 
            string userCookieWithUserToken, 
            string userCertPath)
        {
            return PostWithRsa<List<PajkRenewTkAndWtkResult>>(
                            PajkMethods.UserRenewUserTokenAndWebToken, userId, 
                            CookieUtil.GetCookieValue(userCookieWithUserToken, "_tk"), 
                            userCertPath);
        }

        /// <summary>
        /// 获取WebUserToken
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="userCookieWithUserToken">cookie，包含_tk</param>
        /// <param name="userCertPath">证书文件路径</param>
        /// <returns></returns>
        public PajkResult<List<PajkStringValueResult>> GetWebUserToken(string userId, string userCookieWithUserToken, string userCertPath)
        {
            return PostWithRsa<List<PajkStringValueResult>>(
                            PajkMethods.UserGetWebToken, userId,
                            CookieUtil.GetCookieValue(userCookieWithUserToken, "_tk"),
                            userCertPath);
        }

        public static string PostData(string data)
        {
            return PostData(data, null);
        }

        public static string PostData(string data, string cookie)
        {
            System.Net.HttpWebRequest req = System.Net.WebRequest.Create(DEFAULT_URL) as HttpWebRequest;
            req.Method = "POST";
            using (var sw = req.GetRequestStream())
            {
                byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
                sw.Write(dataBytes, 0, dataBytes.Length);
            }
            req.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            if (cookie != null && cookie.Trim().Length > 0)
            {
                req.Headers[HttpRequestHeader.Cookie] = cookie;//设置Cookie 
            }
            SetProxy(req);

            System.Net.HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            using (var sr = new StreamReader(resp.GetResponseStream()))
            {
                string str = sr.ReadToEnd();

                return str;
            }
        }

        #region 游戏中心

        /// <summary>
        /// 玩一把步步招财游戏
        /// </summary>
        /// <param name="cookie">平安好医生Cookie</param>
        /// <param name="amount">需要消耗的金额，单位：金</param>
        /// <returns></returns>
        public PlayBBZCResult PlayBBZC(string cookie, float amount)
        {
            string requestUrl = "http://promotion.jk.cn/promotion/lottery/healthDraw";

            HttpWebRequest req = WebRequest.Create(requestUrl) as HttpWebRequest;
            req.Method = "POST";
            req.ContentType = DEFAULT_CONTENTTYPE;
            req.Timeout = DEFAULT_TIMEOUT;
            req.Headers[HttpRequestHeader.Cookie] = cookie;
            SetProxy(req);

            ParaCollection pc = new ParaCollection();
            pc.Add("activityCode", "STEP_COUNTER");
            pc.Add("amount", amount * 100);
            pc.Add("_sm", "md5");
            string postData = pc.ToString() +  "&_sig=" + CalcSig(pc.ToString(), cookie);

            byte[] data = System.Text.Encoding.UTF8.GetBytes(postData);
            req.ContentLength = data.Length;
            using (Stream stream = req.GetRequestStream())
            {
                stream.Write(data,0,data.Length);
            }

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if(resp.StatusCode != HttpStatusCode.OK)
                throw new Exception("摇一摇失败," + resp.StatusCode);

            using (var stream = new StreamReader(resp.GetResponseStream()))
            {
                string respResult = stream.ReadToEnd();
                
                var playResult = JsonConvert.DeserializeObject<PlayBBZCResult>((JsonConvert.DeserializeObject(respResult) as JObject)["t"].ToString());
                playResult.money *= 0.01f;//转换为金

                return playResult;
            }
        }

        /// <summary>
        /// 玩一把步步成名游戏
        /// </summary>
        /// <param name="gameCookie">游戏Cookie</param>
        /// <param name="amount">需要消耗的金额，单位：金</param>
        public PlayBBCMResult PlayBBCM(string gameCookie, float amount)
        {
            //http://wap.pahys.com/?act=game_zcsm&st=play&amount=0.2 

            string requestUrl = "http://wap.pahys.com/?act=game_zcsm&st=play&amount=" + amount;
            HttpWebRequest req = WebRequest.Create(requestUrl) as HttpWebRequest;
            req.Method = "GET";
            req.Timeout = DEFAULT_TIMEOUT;
            SetProxy(req);
            req.Headers[HttpRequestHeader.Cookie] = gameCookie;
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if(resp.StatusCode!= HttpStatusCode.OK)
                throw new Exception("Play步步成名失败，" + resp.StatusCode);
            using (var stream = new StreamReader(resp.GetResponseStream()))
            {
                string respResult = stream.ReadToEnd();
                var playResult = JsonConvert.DeserializeObject<PlayBBCMResult>(respResult);
                if(playResult.statusCode == "1100") // 余额不足
                    throw new Exception("余额不足！");

                return playResult;
            }
        }

        /// <summary>
        /// 获取游戏中心Cookie
        /// </summary>
        /// <param name="papdCookie"></param>
        /// <param name="gameUrl"></param>
        /// <returns></returns>
        public string GetGameCookie(string papdCookie, string gameUrl)
        {
            GameSignatureInfo info = GetWLTGameSignature(papdCookie, gameUrl);
            string gameCookie = GetWLTGameCookie(info, gameUrl);

            // 只提取需要的cookie部分
            StringBuilder builder = new StringBuilder();
            string[] cookies = gameCookie.Split(",; ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var cookie in cookies)
            {
                string[] parts = cookie.Split("= ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2)
                    continue;
                if (parts[0] == "PAHYSGAMESID"||
                    parts[0] == "PHPSESSID")
                {
                    // 必须要有这两个cookie的值
                    builder.Append(parts[0] + "=" + parts[1] + ";");
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// 获取游戏中心签名信息
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="gameUrl">例如：http://wap.pahys.com/?act=game_zcsm </param>
        /// <returns></returns>
        private GameSignatureInfo GetWLTGameSignature(string cookie, string gameUrl)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("_mt", "resourcecenter.getWLTGameSignature");
            pc.Add("gameUrl", gameUrl, true);
            pc.Add("_sm", "md5");

            //注意：计算校验位时，使用md5方式计算，不需要cookie，但是请求需要cookie
            string postData = pc + "&_sig=" + CalcSig(pc.ToString(), null); 
            System.Net.HttpWebRequest req = System.Net.WebRequest.Create(DEFAULT_URL) as System.Net.HttpWebRequest;
            InitRequest(req, cookie);
            InitPostData(req, postData);
            string respData = GetResponseString(req);
            CheckResponseState(respData);

            JArray content = (JsonConvert.DeserializeObject(respData) as JObject)["content"] as JArray;

            return JsonConvert.DeserializeObject<GameSignatureInfo>(content[0].ToString());
        }

        /// <summary>
        /// 获取游戏中心Cookie
        /// </summary>
        /// <param name="sigInfo">签名信息</param>
        /// <param name="gameUrl"></param>
        /// <returns></returns>
        private string GetWLTGameCookie(GameSignatureInfo sigInfo, string gameUrl)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("clientId", sigInfo.clientId);
            pc.Add("userId", sigInfo.userId);
            pc.Add("targetUrl", UrlEncodeInUpper(gameUrl)); // 注：targetUrl的值进行了两次URLEncode计算
            pc.Add("timeStamp", sigInfo.timeStamp);
            pc.Add("userName", sigInfo.userName);
            pc.Add("sign", sigInfo.signature);

            string reqUrl = "http://wap.pahys.com/?act=landing&st=partner_sso&&";
            foreach (KeyValuePair<string, string> para in pc)
            {
                reqUrl += para.Key;
                reqUrl += "=";
                reqUrl += UrlEncodeInUpper(para.Value);// 注：由于服务器对大小写敏感，所以URLEncode编码后，编码的部分必须为大写
                reqUrl += "&";
            }
            reqUrl = reqUrl.Substring(0, reqUrl.Length - 1);

            Console.WriteLine(reqUrl);
            System.Net.HttpWebRequest req = System.Net.WebRequest.Create(reqUrl) as System.Net.HttpWebRequest;
            req.Method = "GET";
            SetProxy(req);
            req.Timeout = DEFAULT_TIMEOUT;
            req.AllowAutoRedirect = false; //注：此处不能自动跳转
            System.Net.HttpWebResponse resp = req.GetResponse() as System.Net.HttpWebResponse;

            /*
             * 返回值为以下状态时，则表示成功：
             *  StatusCode:Redirect
                StatusDescription:Moved Temporarily
             */

            if (resp.StatusCode != HttpStatusCode.Redirect)
                throw new Exception("请求失败，" + resp.StatusDescription);

            return resp.Headers["Set-Cookie"];
        }

        /// <summary>
        /// 对字符串进行URLEncode加密，并加密部分转换为大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string UrlEncodeInUpper(string str)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in str)
            {
                string encode = System.Web.HttpUtility.UrlEncode(c.ToString());
                if (encode.Length > 1)
                {
                    // 已进行UrlEncode加密
                    builder.Append(encode.ToUpper());
                }
                else
                {
                    builder.Append(c);
                }
            }

            return builder.ToString();
        }
        #endregion

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public UserInfo GetUserInfo(string cookie)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("_mt", "user.getUserInfo");
            pc.Add("_chl", "android%7C360ZS");

            string response = Post(pc.ToString(), cookie);

            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            return JsonConvert.DeserializeObject<UserInfo>(obj["content"][0].ToString());
        }

        /// <summary>
        /// 老接口
        /// </summary>
        /// <param name="isOnlyShowHealthGoldProduct">是否只获取全部用健康金兑换的商品</param>
        /// <returns></returns>
        public List<IProductInfo> GetExchangeProductsV1(bool isOnlyShowHealthGoldProduct)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("_mt", "shennongSales.getSuperActivityColumns");
            pc.Add("actId", "176");
            pc.Add("_chl", "android%7C360ZS");

            string response = Post(pc.ToString(), null);

            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JArray content = (JArray)obj["content"];

            //解析
            var products = new List<IProductInfo>();

            JArray valueNode = content[0]["value"] as JArray;
            JArray productsNode = valueNode[0]["products"] as JArray;
            for (int i = 0; i < productsNode.Count; i++)
            {
                JObject productNode = productsNode[i] as JObject;
                OldProductInfo product = JsonConvert.DeserializeObject<OldProductInfo>(productNode.ToString());

                if (isOnlyShowHealthGoldProduct)
                {
                    if(!product.IsFullHealthGoldProduct)
                        continue;
                }

                products.Add(product);
            }
            return products;
        }

        /// <summary>
        /// 全额兑换
        /// </summary>
        /// <param name="isOnlyShowHealthGoldProduct">是否只获取全部用健康金兑换的商品</param>
        /// <returns></returns>
        public List<IProductInfo> GetExchangeProductsWithFull(bool isOnlyShowHealthGoldProduct)
        {
            return GetExchangeProductsByActivityId(1915, isOnlyShowHealthGoldProduct);
        }

        /// <summary>
        /// 半价兑换
        /// </summary>
        /// <param name="isOnlyShowHealthGoldProduct"></param>
        /// <returns></returns>
        public List<IProductInfo> GetExchangeProductsWithHalf(bool isOnlyShowHealthGoldProduct)
        {
            //return GetExchangeProductsByActivityId(269, isOnlyShowHealthGoldProduct);
            return GetExchangeProductsByActivityId(1916, isOnlyShowHealthGoldProduct);
        }

        /// <summary>
        /// 超值兑换
        /// </summary>
        /// <param name="isOnlyShowHealthGoldProduct"></param>
        /// <returns></returns>
        public List<IProductInfo> GetExchangeProductsWithPrivilege(bool isOnlyShowHealthGoldProduct)
        {
            return GetExchangeProductsByActivityId(1917, isOnlyShowHealthGoldProduct);
        }

        private List<IProductInfo> GetExchangeProductsByActivityId(int activityId, bool isOnlyShowHealthGoldProduct)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("id", activityId.ToString());
            pc.Add("city", "");
            pc.Add("nearByStoreIds", "[]");
            pc.Add("_mt", "unicorn.getModuleById");
            pc.Add("_chl", "android|360ZS");

            string response = Post(pc.ToString(), null);

            //过滤
            response = response.Replace(@"\\\""", "\"");
            response = response.Replace(@"\""", "\"");
            response = response.Replace("\"{", "{");
            response = response.Replace("}\"", "}");

            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject content = obj["content"][0] as JObject;

            //解析
            var productList = new List<IProductInfo>();
            JArray sectionsNode = content["sections"] as JArray;
            for (int i = 0; i < sectionsNode.Count; i++)
            {
                JObject sectionNode = sectionsNode[i] as JObject;
                JObject productNode = sectionNode["content"] as JObject;
                ProductInfo product = JsonConvert.DeserializeObject<ProductInfo>(productNode.ToString());

                if (isOnlyShowHealthGoldProduct)
                {
                    if (!product.IsFullHealthGoldProduct)
                        continue;
                }

                productList.Add(product);
            }

            return productList;
        }

        /// <summary>
        /// 获取商品详情
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <param name="storeId">商店ID</param>
        /// <returns></returns>
        public ProductDetail GetProductDetail(long productId, long storeId)
        {
            string data = string.Format(
                "_mt=unicorn.getProductDetail&spuId={0}&storeId={1}&_chl=android%7CMZSD",
                        productId, storeId);
            string response = Post(data, null);

            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject content = obj["content"][0] as JObject;

            return JsonConvert.DeserializeObject<ProductDetail>(content.ToString());
        }

        /// <summary>
        /// 查询奖励
        /// </summary>
        /// <returns></returns>
        public RewardInfo QueryRewardInfo(string cookie, int stepCount)
        {
            string data = "_mt=promotion.queryRewardInfo&activityCode=STEP_COUNTER&totalStep=" + stepCount;
            string response = Post(data, cookie);

            //解析
            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JArray jaContent = obj["content"] as JArray;
            JObject joInfo = jaContent[0] as JObject;

            return JsonConvert.DeserializeObject<RewardInfo>(joInfo.ToString());
        }

        /// <summary>
        /// 领取奖励
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public string FetchReward(string cookie, long rewardId)
        {
            string data = "_mt=promotion.fetchReward&rewardId=" + rewardId + "&_vc=30200";

            string responseString = Post(data, cookie);

            return responseString;
        }

        /// <summary>
        /// 查询所有订单
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="type"></param>
        /// <param name="pageNo"></param>
        /// <returns></returns>
        public List<OrderInfo> QueryOrders(string cookie,OrderType type, int pageNo)
        {
            string data = "_mt=unicorn.pageQueryOrderForBuyer&pageNo=" + pageNo + "&pageSize=6&statusCode=" + type + "&_chl=android%7C360ZS";
            string responseString = Post(data, cookie);

            JObject obj = JsonConvert.DeserializeObject(responseString) as JObject;
            JObject content = obj["content"][0] as JObject;
            //"totalCount": 14,"pageNo": 1,"pageSize": 10,
            int totalCount = Convert.ToInt32(content["totalCount"].ToString());
            JArray mainOrders = content["mainOrders"] as JArray;

            List<OrderInfo> list = new List<OrderInfo>();
            for (int i = 0; i < mainOrders.Count; i++)
            {
                JObject order = mainOrders[i] as JObject;
                OrderInfo orderInfo = JsonConvert.DeserializeObject<OrderInfo>(order["tradeOrder"].ToString());
                orderInfo.buttonStatus = JsonConvert.DeserializeObject<ButtonStatusInfo>(order["buttonStatus"].ToString());

                list.Add(orderInfo);
            }

            return list;
        }

        /// <summary>
        /// 查询订单详情
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="orderId">订单ID</param>
        /// <returns></returns>
        public OrderDetailInfo QueryOrderDetailInfo(string cookie, string orderId)
        {
            string data = "_mt=unicorn.queryOrderForBuyer&bizOrderId=" + orderId + "&_chl=android%7CMZSD";
            string responseString = Post(data, cookie);

            JObject obj = JsonConvert.DeserializeObject(responseString) as JObject;
            JObject content = obj["content"][0] as JObject;

            return JsonConvert.DeserializeObject<OrderDetailInfo>(content.ToString());
        }

        /// <summary>
        /// 从历史订单中获取手机号
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public List<string> GetHistoryOrderMobiles(string cookie)
        {
            List<string> mobiles = new List<string>();
            int pageNo = 1;
            List<OrderInfo> orders = new List<OrderInfo>();
            while (true)
            {
                var list = QueryOrders(cookie, OrderType.FINISH,pageNo++);
                if (list.Count < 1)
                    break;
                orders.AddRange(list);
            }
            orders = orders.OrderByDescending(o => o.createTime).ToList();//从最近的订单开始遍历
            int orderDetailQueryCount = 0;
            foreach (var order in orders)
            {
                if (order.items[0].itemTitle.Contains("话费"))
                {
                    orderDetailQueryCount++;
                    if (orderDetailQueryCount > 10)//从最近的10单话费充值中，获取手机号
                        break;
                    var orderDetail = QueryOrderDetailInfo(cookie, order.tradeId);
                    var mobile = orderDetail.address.mobile;

                    if (string.IsNullOrEmpty(mobile))
                        continue;
                    if (mobiles.Contains(mobile))
                        continue;
                    mobiles.Add(mobile);
                }
            }

            return mobiles;
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="orderId">订单号</param>
        /// <returns></returns>
        public void CloseOrder(string cookie, long orderId)
        {
            string data = "_mt=unicorn.closeOrder&orderId=" + orderId + "&_chl=android%7CMZSD";
            string response = Post(data, cookie);

            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject content = obj["content"][0] as JObject;

            if (!Convert.ToBoolean(content["value"].ToString()))
                throw new Exception("订单取消失败");
        }

        /// <summary>
        /// 获取支付地址
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="orderId"></param>
        public string GetPayUrl(string cookie, long orderId)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("_mt", "unicorn.getPayUrl");
            pc.Add("_chl", "android|360ZS");
            pc.Add("_sm", "md5");
            pc.Add("orderIds", string.Format("[\"{0}\"]", orderId));

            string response = Post(pc.ToString(), cookie);

            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject content = obj["content"][0] as JObject;

            return content["url"].ToString();
        }

        /// <summary>
        /// 获取步步抢金
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="pageNo"></param>
        /// <returns></returns>
        public GrabGoldInfo GetGrabGoldInfo(string cookie, int pageNo)
        {
            string data = "_mt=promotion.getFollowerRankingList&activityCode=STEP_COUNTER&pageNo=" + pageNo + "&pageSize=10";
            string response = Post(data, cookie);

            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject contentObject = obj["content"][0] as JObject;

            return JsonConvert.DeserializeObject<GrabGoldInfo>(contentObject.ToString());
        }

        /// <summary>
        /// 获取好友排行榜
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="pageNo"></param>
        /// <returns></returns>
        public RankingInfo GetFriendRankingList(string cookie, int pageNo)
        {
            string data = "_mt=promotion.pageGetFollowerRankingList&activityCode=STEP_COUNTER&pageNo=" + pageNo + "&pageSize=10";
            string response = Post(data, cookie);

            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject contentObject = obj["content"][0] as JObject;

            return JsonConvert.DeserializeObject<RankingInfo>(contentObject.ToString());
        }

        /// <summary>
        /// 获取赚钱排行榜
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public RankingInfo GetBonusRankingList(string cookie)
        {
            return GetBonusRankingList(cookie, 1);
        }

        /// <summary>
        /// 获取赚钱排行榜（服务端最多返回前200名的数据）
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="pageNo"></param>
        /// <returns></returns>
        public RankingInfo GetBonusRankingList(string cookie,int pageNo)
        {
            string data = "_mt=promotion.pageGetBonusRankingList&activityCode=STEP_COUNTER&pageNo=" + pageNo + "&pageSize=10";
            string response = Post(data, cookie);

            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject contentObject = obj["content"][0] as JObject;

            return JsonConvert.DeserializeObject<RankingInfo>(contentObject.ToString());
        }

        /// <summary>
        /// 叫Ta领钱
        /// </summary>
        public void NoticeBonusToFollower(string cookie, long followerId)
        {
            string data =
                "_mt=promotion.noticeBonusToFollower&activityCode=STEP_COUNTER&followerId=" + followerId;
            string response = Post(data, cookie);

            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject content = obj["content"][0] as JObject;

            if (!Convert.ToBoolean(content["isSuccess"].ToString()))
            {
                throw new Exception("提醒失败！");
            }
        }

        /// <summary>
        /// 表扬 Ta
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="followId"></param>
        public void PraiseToFollower(string cookie, long followId)
        {
            string data =
                "_mt=promotion.addNewPraiseToFollower&activityCode=STEP_COUNTER&followerId=" + followId;
            string response = Post(data, cookie);

            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject content = obj["content"][0] as JObject;

            if (!Convert.ToBoolean(content["isSuccess"].ToString()))
            {
                throw new Exception("Praise失败！");
            }
        }

        /// <summary>
        /// 马上抢金
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="fId">好友id</param>
        public void GrabGoldFromFollower(string cookie, long fId)
        {
            string data =
                "_mt=promotion.fetchFriendReward&fId=" + fId;
            string response = Post(data, cookie);

            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject content = obj["content"][0] as JObject;

            if (!Convert.ToBoolean(content["isSuccess"].ToString()))
            {
                throw new Exception("抢金失败！");
            }
        }

        /// <summary>
        /// 获取已邀请的好友个数
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public int GetInviteeCount(string cookie)
        {
            string data = "_mt=promotion.getInviteeTotal";
            string response = Post(data, cookie);

            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject content = obj["content"][0] as JObject;

            return Convert.ToInt32(content["total"]);
        }

        /// <summary>
        /// 获取被邀请的好友
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="isInviteSuccess">是：获取已成功邀请的好友；否：获取正在邀请的好友</param>
        /// <param name="pageNo"></param>
        /// <returns></returns>
        public List<InviteeInfo> GetInvitees(string cookie,bool isInviteSuccess,int pageNo)
        {
            int code = 1;
            if(isInviteSuccess)
                code = 2;
            string data = "_mt=promotion.getInviteeByUserId&status=" + code + "&pageNo=" + pageNo + "&pageSize=6";
            string response = Post(data, cookie);

            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject content = obj["content"][0] as JObject;
            JArray invitees = content["invitees"] as JArray;

            List<InviteeInfo> list = new List<InviteeInfo>();
            for (int i = 0; i < invitees.Count; i++)
            {
                JObject invitee = invitees[i] as JObject;

                list.Add(JsonConvert.DeserializeObject<InviteeInfo>(invitee.ToString()));
            }

            return list;
        }

        /// <summary>
        /// 获取邀请二维码信息
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public InviteCodeInfo GetInviteQRInfo(string cookie)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("_mt", "promotion.getInviteCode");

            string response = Post(pc.ToString(), cookie);
            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject content = obj["content"][0] as JObject;

            return JsonConvert.DeserializeObject<InviteCodeInfo>(content.ToString());
        }

        /// <summary>
        /// 快速邀请好友
        /// </summary>
        /// <param name="inviteCode">邀请码</param>
        /// <param name="phoneNumber">好友手机号</param>
        /// <returns></returns>
        public void QuickInvite(string inviteCode, string phoneNumber)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("_mt", "promotion.getStepAwardByCode");
            pc.Add("numberType", "MOBILE");
            pc.Add("inviteCode",inviteCode);
            pc.Add("number",phoneNumber);
            pc.Add("verifyCode",string.Empty);

            string response = Post(pc.ToString(),null, false);
            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject content = obj["content"][0] as JObject;

            if (!Convert.ToBoolean(content["isSuccess"].ToString()))
            {
                CheckResponseState(response);
            }
        }

        /// <summary>
        /// 提醒用户完成注册
        /// </summary>
        /// <param name="inviteeInfo"></param>
        /// <param name="cookie"></param>
        public void NoticeRegisterToInvitee(InviteeInfo inviteeInfo, string cookie)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("_mt", "promotion.noticeRegisterToInvitee");
            pc.Add("activityCode", "STEP_COUNTER");
            pc.Add("inviteeId",inviteeInfo.userId.ToString());
            pc.Add("mobile",inviteeInfo.mobile);

            string response = Post(pc.ToString(), cookie);
            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject content = obj["content"][0] as JObject;

            if (!Convert.ToBoolean(content["isSuccess"].ToString()))
            {
                throw new Exception("");
            }
        }

        /// <summary>
        /// 查询收支明细
        /// </summary>
        /// <param name="cookie"></param>
        public List<RewardRecordInfo> QueryBatchOrderRecord(string cookie)
        {
            List<RewardRecordInfo> list = new List<RewardRecordInfo>();

            string data = "_mt=promotion.queryBatchOrderRecord&activityCode=STEP_COUNTER&pageNo=1&pageSize=100";
            string response = Post(data, cookie);

            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject content = obj["content"][0] as JObject;
            int total = Convert.ToInt32(content["total"].ToString());
            if (total < 1)
            {
                return list;
            }

            JArray rewardRecords = content["rewardRecordInfoList"] as JArray;
            for (int i = 0; i < rewardRecords.Count; i++)
            {
                JObject rewardRecord = rewardRecords[i] as JObject;

                list.Add(JsonConvert.DeserializeObject<RewardRecordInfo>(rewardRecord.ToString()));
            }

            return list;
        }

        /// <summary>
        /// 获取夺金明细
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public List<RewardRecordInfo> GetRewardRecordInfos(string cookie)
        {
            List<RewardRecordInfo> list = new List<RewardRecordInfo>();

            string data = "_mt=promotion.getRewardRecordInfoListV2&activityCode=STEP_COUNTER&pageNo=1&pageSize=100";
            string response = Post(data, cookie);

            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject content = obj["content"][0] as JObject;
            int total = Convert.ToInt32(content["total"].ToString());
            if (total < 1)
            {
                return list;
            }

            JArray rewardRecords = content["rewardRecordInfoList"] as JArray;
            for (int i = 0; i < rewardRecords.Count; i++)
            {
                JObject rewardRecord = rewardRecords[i] as JObject;

                list.Add(JsonConvert.DeserializeObject<RewardRecordInfo>(rewardRecord.ToString()));
            }

            return list;
        }

        /// <summary>
        /// 获取幸福金信息
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public GoldInfo GetGoldInfo(string cookie)
        {
            string data = "_mt=promotion.getGoldConsumeSummary&activityCode=STEP_COUNTER";
            string response = Post(data, cookie);

            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JArray content = obj["content"] as JArray;
            return JsonConvert.DeserializeObject<GoldInfo>(content[0].ToString());
        }

        /// <summary>
        /// 查询用户余额
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public int GetUserBalance(string cookie)
        {
            string data = "_mt=unicorn.queryPointBalance&_chl=android%7CMZSD";
            string response = Post(data, cookie);

            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject content = obj["content"][0] as JObject;
            int balance = content["balance"].Value<int>();
            int freezeBalance = content["freezeBalance"].Value<int>();

            return balance;
        }

        /// <summary>
        /// 获取所有收货地址
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public List<AddressInfo> GetAllAddress(string cookie)
        {
            string data = "_mt=address.getAllAddressesByBiz&bizType=mall&_chl=android%7CMZSD";
            string response = Post(data, cookie);

            List<AddressInfo> list = new List<AddressInfo>();
            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject content = obj["content"][0] as JObject;

            //如果没有值，未添加任何收货地址
            if (!content.HasValues)
                return list;

            JArray addresses = content["value"] as JArray;
            for (int i = 0; i < addresses.Count; i++)
			{
			    list.Add(JsonConvert.DeserializeObject<AddressInfo>(addresses[i].ToString()));
			}

            return list;
        }

        /// <summary>
        /// 添加或更新收货地址
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="addressInfo">收货地址信息</param>
        public void AddOrUpdateAddress(string cookie, AddressInfo addressInfo)
        {
            var setting = new JsonSerializerSettings();
            setting.NullValueHandling = NullValueHandling.Ignore;
            string value = JsonConvert.SerializeObject(addressInfo, Formatting.None, setting);
            string valueUrlEncode = System.Web.HttpUtility.UrlEncode(value, Encoding.UTF8);

            string data = "_mt=address.saveOrUpdateAddress&myAddressReq=" + valueUrlEncode + "&_chl=android|MZSD";
            string response = Post(data, cookie);

        }

        /// <summary>
        /// 删除收货地址
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="addressId">收货地址ID</param>
        public void DeleteAddress(string cookie, long addressId)
        {
            string data = "_mt=address.deleteAddressById&id=" + addressId + "&_chl=android%7CMZSD";
            string response = Post(data, cookie);

            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject content = obj["content"][0] as JObject;
            if (!Boolean.Parse(content["value"].ToString()))
            {
                throw new Exception("删除地址失败");
            }
        }

        /// <summary>
        /// 获取所有省
        /// </summary>
        /// <returns></returns>
        public List<ProvinceInfo> GetAllProvinces()
        {
            return GetProvinceOrCityOrProvince<ProvinceInfo>("_mt=address.getAllProvinces&_chl=android%7CMZSD");
        }

        /// <summary>
        /// 获取所有市
        /// </summary>
        /// <returns></returns>
        public List<CityInfo> GetAllCities()
        {
            return GetProvinceOrCityOrProvince<CityInfo>("_mt=address.getAllCities&_chl=android%7CMZSD");
        }

        /// <summary>
        /// 获取省所在的市
        /// </summary>
        /// <param name="provinceCode"></param>
        /// <returns></returns>
        public List<CityInfo> GetAllCitiesByProvinceCode(string provinceCode)
        {
            return GetProvinceOrCityOrProvince<CityInfo>("_mt=address.getAllCitiesByProvinceCode&provinceCode=" + provinceCode);
        }

        /// <summary>
        /// 获取市所在的区
        /// </summary>
        /// <returns></returns>
        public List<DistrictInfo> GetAllDistrictsByCityCode(string cityCode)
        {
            return GetProvinceOrCityOrProvince<DistrictInfo>("_mt=address.getAllDistrictsByCityCode&cityCode=" + cityCode);
        }

        /// <summary>
        /// 获取省、市或区
        /// </summary>
        /// <returns></returns>
        public List<T> GetProvinceOrCityOrProvince<T>(string data)
        {
            string response = Post(data, null);

            JObject obj = JsonConvert.DeserializeObject(response) as JObject;
            JObject content = obj["content"][0] as JObject;
            JArray value = content["value"] as JArray;

            List<T> list = new List<T>();
            for (int i = 0; i < value.Count; i++)
            {
                var info = value[i] as JObject;
                list.Add(JsonConvert.DeserializeObject<T>(info.ToString()));
            }

            return list;
        }

        /// <summary>
        /// 根据图片编码地址获取Image
        /// </summary>
        /// <param name="imageCode"></param>
        /// <returns></returns>
        public Image GetImageByPapdCode(string imageCode)
        {
            System.Net.WebClient client = new WebClient();
            string imageUrl = GetImageUrl(imageCode);
            byte[] data = client.DownloadData(imageUrl);
            using (var ms = new MemoryStream())
            {
                ms.Write(data,0,data.Length);

                return Image.FromStream(ms);
            }
        }

        /// <summary>
        /// 查看总价
        /// </summary>
        /// <returns></returns>
        public bool GetTotalFee(long productId, long storeId, string cookie)
        {
            //查询商品详情
            var productDetail = GetProductDetail(productId, storeId);

            #region 生成订单参数
            CreateOrderInfo[] childOrders = new CreateOrderInfo[productDetail.items.Length];
            for (int i = 0; i < childOrders.Length; i++)
            {
                childOrders[i] = new CreateOrderInfo();
                childOrders[i].sellerId = productDetail.seller.id;
                childOrders[i].storeId = productDetail.items[i].storeStock.id;
                childOrders[i].skus = new SkuInfo[1];
                childOrders[i].skus[0] = new SkuInfo();
                childOrders[i].skus[0].skuId = productDetail.items[i].id;
                childOrders[i].skus[0].piece = 1;
                childOrders[i].skus[0].trace = "u.7-" + productId;
                //childOrders[i].skus[0].trace =
                //    string.Format("t.u-all.6-{0}.k-3?from=duojin&usableCoupon=0&fullExchange=1.6-{0}", productId);
                childOrders[i].skus[0].promPrice = 0;
            }
            #endregion

            ParaCollection pc = new ParaCollection();
            pc.Add("_chl", Default_CHL);
            pc.Add("_mt", "unicorn.getTotalFee");
            pc.Add("_sm", "md5");
            pc.Add("products", JsonConvert.SerializeObject(childOrders, Formatting.None), true);
            pc.Add("args", JsonConvert.SerializeObject(new CreateOrderInfoParaList(), Formatting.None), true);

            var result = PostRequest<List<PajkValueResult<bool>>>(pc, cookie, true);

            return result.Content[0].Value;
        }
        
        /// <summary>
        /// 检查订单状态
        /// </summary>
        /// <returns></returns>
        public bool CheckOrderRight(string productId, string cookie)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("_chl", Default_CHL);
            pc.Add("_mt", "unicorn.checkOrderRight");
            pc.Add("_sm", "md5");
            pc.Add("items", string.Format("[{{\"id\":\"{0}\"}}]", productId), true);

            var result = PostRequest<List<PajkValueResult<bool>>>(pc, cookie, true);

            return result.Content[0].Value;
        }

        /// <summary>
        /// 检查验证码
        /// </summary>
        /// <returns></returns>
        public bool CheckVerifyCode(string cookie, string itemId, string storeId, string verifyCode)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("_chl", Default_CHL);
            pc.Add("_mt", "unicorn.checkVerifyCode");
            pc.Add("_sm", "md5");
            pc.Add("actId", "176");
            pc.Add("itemId", itemId);
            pc.Add("storeId", storeId);
            pc.Add("verifyCode", verifyCode);

            var result = PostRequest<List<PajkValueResult<bool>>>(pc, cookie, false);

            return result.Content[0].Value;
        }

        /// <summary>
        /// 发送post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pc">参数列表，其中_sig值可以没有，内部会进行计算</param>
        /// <param name="cookie">cookie值，可以为null</param>
        /// <param name="useCookieToCalcSig">是否使用cookie计算签名</param>
        /// <returns></returns>
        private PajkResult<T> PostRequest<T>(ParaCollection pc, string cookie, bool useCookieToCalcSig) where T:new()
        {
            if(!pc.ContainsKey("_sig"))
                pc.Add("_sig", CalcSig(pc.ToString(), useCookieToCalcSig?cookie:null));

            string respStr = PostData(pc.ToString(), cookie);

            CheckResponseState(respStr);

            return JsonConvert.DeserializeObject<PajkResult<T>>(respStr);
        }

        /// <summary>
        /// 获取验证码（byte[]格式）
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public byte[] GetVerifyCodeInByteArray(string cookie)
        {
            return Convert.FromBase64String(GetVerifyCodeInBase64(cookie));
        }

        /// <summary>
        /// 获取验证码（base64格式）
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public string GetVerifyCodeInBase64(string cookie)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("_chl", Default_CHL);
            pc.Add("_mt", "unicorn.getVerifyCode");
            pc.Add("_sm", "md5");
            pc.Add("actId", "176");

            var result = PostRequest<List<PajkValueResult<string>>>(pc, cookie, false);
            return result.Content[0].Value;
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public Image GetVerifyCode(string cookie)
        {
            using (var stream = new MemoryStream(GetVerifyCodeInByteArray(cookie)))
            {
                return Image.FromStream(stream);
            }
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="productId"></param>
        /// <param name="storeId"></param>
        /// <param name="rechargePhoneNumber">充值手机号</param>
        /// <param name="addressInfo">收货地址</param>
        /// <returns>返回订单支付成功地址或继续支付地址</returns>
        public string CreateOrder(string cookie, 
            long productId, long storeId, string rechargePhoneNumber, AddressInfo addressInfo)
        {
            //查询商品详情
            var productDetail = GetProductDetail(productId, storeId);

            //判断是否余额不足
            var balance = GetUserBalance(cookie);
            if (productDetail.price > balance)
            {
                throw new Exception("余额不足");
            }

            #region 生成订单参数
            CreateOrderInfo[] childOrders = new CreateOrderInfo[productDetail.items.Length];
            for (int i = 0; i < childOrders.Length; i++)
            {
                childOrders[i] = new CreateOrderInfo();
                childOrders[i].sellerId = productDetail.seller.id;
                childOrders[i].storeId = productDetail.items[i].storeStock.id;
                childOrders[i].skus = new SkuInfo[1];
                childOrders[i].skus[0] = new SkuInfo();
                childOrders[i].skus[0].skuId = productDetail.items[i].id;
                childOrders[i].skus[0].piece = 1;
                //childOrders[i].skus[0].trace = "u.7-" + productId;
                childOrders[i].skus[0].trace =
                    string.Format("t.u-all.6-{0}.k-3?from=duojin&usableCoupon=0&fullExchange=1.6-{0}", productId);
                childOrders[i].skus[0].promPrice = 0;
            }

            CreateOrderInfoPara para = new CreateOrderInfoPara();
            para.source = 1;
            para.isHealthGold = true;
            para.addressId = addressInfo == null ? 0 : addressInfo.id;
            para.userMobile = productDetail.title.Contains("手机话费") ? rechargePhoneNumber : string.Empty;
            para.invoice = new InvoiceInfo();
            para.invoice.type = InvoiceType.个人;
            para.invoice.title = InvoiceType.个人.ToString();

            ParaCollection pc = new ParaCollection();
            pc.Add("_mt", "unicorn.createOrder");
            pc.Add("childOrders", JsonConvert.SerializeObject(childOrders, Formatting.None), true);
            pc.Add("args", JsonConvert.SerializeObject(para, Formatting.None), true);
            pc.Add("_chl", "android|MZSD"); 
            #endregion

            //发送请求
            var result = Post(pc.ToString(), cookie);

            if (OutputEvent != null)
            {
                OutputEvent(pc.ToString(),new EventArgs());
            }

            //解析请求结果
            JObject obj = JsonConvert.DeserializeObject(result) as JObject;
            JObject content = obj["content"][0] as JObject;
            string successUrl = content["url"].ToString();

            if (successUrl.StartsWith("http://paygw.jk.cn/") || successUrl.StartsWith("https://paygw.jk.cn/"))
            {
                throw new Exception("请在待支付订单页面，继续支付！");
            }
            else
            {
                if (!successUrl.StartsWith("http://") && !successUrl.StartsWith("https://"))
                {
                    throw new Exception("返回数据错误，" + successUrl);
                } 
            }

            return successUrl;
        }

        /// <summary>
        /// 根据商品id获取商品信息（步步夺宝专用）
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="skuId">商品id</param>
        /// <returns></returns>
        public PajkResultList<PajkGetSkus> GetSkusBySkuIds(string cookie, string skuId)
        {
            ParaCollection pc = new ParaCollection();
            pc.Add("_mt", "unicorn.getSkusBySkuIds");
            pc.Add("skuIds", string.Format("[\"{0}\"]", skuId), true);
            pc.Add("_chl", Default_CHL);
            pc.Add("_sm", "md5");

            return GetResultList<PajkGetSkus>(pc, cookie, true);
        }

        /// <summary>
        /// 创建订单（步步夺宝专用）
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="productId"></param>
        /// <param name="storeId"></param>
        /// <param name="rechargePhoneNumber">充值手机号</param>
        /// <param name="addressInfo"></param>
        /// <returns></returns>
        public string CreateOrder2(string cookie,
            string skuId, string rechargePhoneNumber, AddressInfo addressInfo)
        {
            //查询商品详情
            var getSkusResult = GetSkusBySkuIds(cookie, skuId);
            var productDetail = getSkusResult.Content[0].RecipeSkuDTOs[0];

            //判断是否余额不足
            var balance = GetUserBalance(cookie);
            if (productDetail.Price > balance)
            {
                throw new Exception("余额不足");
            }

            #region 生成订单参数
            CreateOrderInfo[] childOrders = new CreateOrderInfo[productDetail.SpuSpecs.Length];
            for (int i = 0; i < childOrders.Length; i++)
            {
                childOrders[i] = new CreateOrderInfo();
                childOrders[i].sellerId = productDetail.SellerId;
                childOrders[i].storeId = productDetail.StoreId;
                childOrders[i].skus = new SkuInfo[1];
                childOrders[i].skus[0] = new SkuInfo();
                childOrders[i].skus[0].skuId = productDetail.SkuId;
                childOrders[i].skus[0].piece = 1;
                childOrders[i].skus[0].trace = "xx";
                childOrders[i].skus[0].promPrice = 0;
            }

            CreateOrderInfoPara para = new CreateOrderInfoPara();
            para.source = 1;
            para.isHealthGold = true;
            para.addressId = addressInfo == null ? 0 : addressInfo.id;
            para.userMobile = productDetail.Name.Contains("手机话费") ? rechargePhoneNumber : string.Empty;
            para.invoice = new InvoiceInfo();
            para.invoice.type = InvoiceType.个人;
            para.invoice.title = InvoiceType.个人.ToString();
            para.callBackUrl = "";

            ParaCollection pc = new ParaCollection();
            pc.Add("_mt", "unicorn.createOrder");
            pc.Add("childOrders", JsonConvert.SerializeObject(childOrders, Formatting.None), true);
            pc.Add("args", JsonConvert.SerializeObject(para, Formatting.None), true);
            pc.Add("_chl", Default_CHL);
            pc.Add("_sm", "md5");
            #endregion

            if (OutputEvent != null)
            {
                OutputEvent(pc.ToString(), new EventArgs());
            }

            //发送请求
            var result = GetResultList<PajkCreateOrderResult>(pc, cookie, true);
            var url = result.Content[0].url;

            if (url.StartsWith("http://paygw.jk.cn/") || url.StartsWith("https://paygw.jk.cn/"))
            {
                throw new Exception("请在待支付订单页面，继续支付！");
            }
            else
            {
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    throw new Exception("返回数据错误，" + url);
                }
            }

            return url;
        }

        #endregion

        #region 辅助
        public string Post(string postData, string cookie)
        {
            return Post(postData, cookie, true);
        }

        public string Post(string postData, string cookie, bool isCheckResponseState)
        {
            HttpWebRequest request = WebRequest.Create(DEFAULT_URL) as HttpWebRequest;

            if (!postData.Contains("_tk="))
            {
                // _tk和_sm两个互斥
                if (!postData.Contains("_sm"))
                {
                    postData += "&_sm=md5"; // 如果不指定_sm，则默认使用md5方式加密
                }
            }

            // 计算校验位
            string sigValue = CalcSig(postData, cookie);
            postData += "&_sig=";
            postData += sigValue;

            InitRequest(request, cookie);
            InitPostData(request, postData);
            string responseString = GetResponseString(request);

            if (isCheckResponseState)
            {
                if (postData.Contains("unicorn.createOrder"))
                {
                    if (OutputEvent != null)
                    {
                        OutputEvent(responseString,new EventArgs());
                    }
                }
                CheckResponseState(responseString); 
            }

            return responseString;
        }

        private void CheckResponseState(string responseString)
        {
            JObject json = (JObject)JsonConvert.DeserializeObject(responseString);
            JObject jStat = (JObject)json["stat"];
            StateInfo stateInfo = JsonConvert.DeserializeObject<StateInfo>(jStat.ToString());

            if (stateInfo.code != 0)
            {
                //throw new Exception("请求失败，" + stateInfo.GetCodeInfo());
                throw new UserStateException(stateInfo);
            }
            else
            {
                if (stateInfo.stateList.Length > 0)
                {
                    var stateItem = stateInfo.stateList[0];
                    if (stateItem.code != 0)
                    {
                        throw new Exception(stateItem.GetCodeInfo());
                    }
                }
            }
        }

        private static void SetProxy(HttpWebRequest request)
        {
            if (Proxy != null)
            {
                request.Proxy = Proxy;
            }
        }

        private void InitRequest(HttpWebRequest request, string cookie)
        {
            SetProxy(request);
            request.Method = HttpMethod.POST.ToString();
            request.ContentType = DEFAULT_CONTENTTYPE;
            request.Timeout = DEFAULT_TIMEOUT;
            if (cookie != null && cookie.Trim().Length > 0)
            {
                request.Headers[HttpRequestHeader.Cookie] = cookie;//设置Cookie 
            }
            request.UserAgent = DEFAULT_USERAGENT;
        }

        private void InitPostData(HttpWebRequest request, string postData)
        {
            byte[] data = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
        }

        /// <summary>
        /// 计算Md5校验位
        /// </summary>
        /// <param name="postData">发送的数据，不能包含“_sig=”</param>
        /// <param name="cookie">cookie，可为空</param>
        public static string CalcSig(string postData, string cookie)
        {
            string combineStr;

            return CalcSig(postData,cookie,null, out combineStr);
        }

        /// <summary>
        /// 计算校验位
        /// </summary>
        public static string CalcSig(string postData, string cookie, string pfxPrivateKey)
        {
            string combineStr;
            return CalcSig(postData, cookie, pfxPrivateKey, out combineStr);
        }

        /// <summary>
        /// 计算校验位
        /// </summary>
        /// <param name="postData">发送的数据，不能包含“_sig=”</param>
        /// <param name="cookie">cookie，可为空</param>
        /// <param name="pfxPrivateKey">pfx证书私钥，如果不需要则设为null</param>
        /// <param name="combineStr">拼接后的字符串</param>
        /// <returns></returns>
        public static string CalcSig(string postData, string cookie, string pfxPrivateKey, out string combineStr)
        {
            if (cookie != null)
                cookie = cookie.Trim();

            //1.提取所有的键值对，并分别进行URL解码
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string[] paramArray = postData.Split("&".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < paramArray.Length; i++)
            {
                string[] array = paramArray[i].Split('=');
                var key = System.Web.HttpUtility.UrlDecode(array[0]);  //对key进行Url解码
                var value = array[1];
                // 为了防止对_tk的值解密后+变成空格的问题
                if(key!="_tk"&&key!="_dtk")
                {
                    value = System.Web.HttpUtility.UrlDecode(array[1]);//对value进行Url解码
                }

                dic.Add(key, value);
            }

            //2.按key进行排序
            dic = dic.OrderBy(paramItem => paramItem.Key)
                .ToDictionary(paramItem => paramItem.Key, pair => pair.Value);

            //3.将参数的key和value依次拼接
            combineStr = string.Empty;
            foreach (var paramItem in dic)
            {
                combineStr += paramItem.Key + "=" + paramItem.Value;//key=value拼接
            }

            //4.追加magic number，并计算校验位
            byte[] hashBytes;
            if (dic.ContainsKey("_sm"))
            {
                /*********根据_sm值使用不同的方式加密*********/

                string encodeType = dic["_sm"];
                if (encodeType == "md5")
                {
                    if (GetCookie(cookie, "_wtk") == null) //cookie中包含_wtk
                        combineStr += "jk.pingan.com";
                    else
                        combineStr += GetCookie(cookie, "_wtk");
                    System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                    hashBytes = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(combineStr));

                    return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                }
                else if (encodeType == "rsa")
                {
                    // 1、用sha1计算hash值
                    // 2、对hash值创建签名
                    System.Security.Cryptography.SHA1Managed sha1Managed = new System.Security.Cryptography.SHA1Managed();//创建sha1托管库对象
                    byte[] hashResult = sha1Managed.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(combineStr));

                    System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider();//创建rsa对象
                    rsa.FromXmlString(pfxPrivateKey);//使用证书私钥初始化rsa对象

                    System.Security.Cryptography.RSAPKCS1SignatureFormatter formatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(rsa);
                    formatter.SetHashAlgorithm("sha1");
                    byte[] signatureResult = formatter.CreateSignature(hashResult);

                    return Convert.ToBase64String(signatureResult);
                }
                else
                {
                    throw new Exception("无法计算校验位，" + postData);
                }
            }
            else
            {
                /*********直接使用sha1加密*********/

                combineStr += "jk.pingan.com";
                // 通过sha1加密
                System.Security.Cryptography.SHA1CryptoServiceProvider sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
                hashBytes = sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(combineStr));

                return Convert.ToBase64String(hashBytes);
            }
        }

        private static string GetCookie(string cookie, string key)
        {
            if (cookie == null)
                return null;

            var arr1 = cookie.Split("; ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var cookieStr in arr1)
            {
                var arr2 = cookieStr.Split("= ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (arr2[0] == key.Trim())
                {
                    return arr2[1];
                }
            }

            return null;
        }

        /// <summary>
        /// 创建邀请链接
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="inviteCode">邀请码</param>
        /// <returns></returns>
        public static string GetInviteUrl(string userId, string inviteCode)
        {
            return string.Format("https://gc.jk.cn/duojin/regist.html?code={0}&data={1}&query=SNS_PROFILE", inviteCode,
                userId);
        }

        private string Base64Decode(string str)
        {
            try
            {
                var data = Convert.FromBase64String(str);

                return System.Text.Encoding.UTF8.GetString(data);
            }
            catch (Exception ex)
            {
                return str;
            }
        }

        private string Base64Encode(string str)
        {
            var data = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(str));

            return data;
        }
        #endregion

        #region 其他

        /// <summary>
        /// 是否需要充值手机号
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public static Boolean IsNeedRechargeMobile(string productName)
        {
            return productName.Contains("手机话费");
        }

        /// <summary>
        /// 输出事件
        /// </summary>
        public event EventHandler OutputEvent;

        /// <summary>
        /// 获取商品详情URL
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public static string GetProductDetailUrl(long productId, long storeId)
        {
            return string.Format("http://yao-h5.s.jk.cn/index.html#/yao-detail/{0}/{1}", productId, storeId);
        }

        /// <summary>
        /// 获取图片URL
        /// </summary>
        /// <returns></returns>
        public static string GetImageUrl(string image)
        {
            return "http://static.jk.cn/" + image;
        }

        /// <summary>
        /// 获取响应字符串
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static string GetResponseString(HttpWebRequest request)
        {
            //响应
            var response = request.GetResponse();
            var responseString = string.Empty;
            using (var stream = response.GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    responseString = sr.ReadToEnd();
                }
            }

            return responseString;
        }

        #region Cookie设置
        /// <summary>
        /// <para>设置cookie时，需要使用管理员方式打开程序，原因：InternetSetCookie是向系统目录中写入文件需要权限</para>
        /// </summary>
        /// <param name="url">(http|https)://(域名|IP地址)</param>
        /// <param name="name">一个Cookie中的Key</param>
        /// <param name="data">一个Cookie中的Value再加上expires、path（可选）(expires=Sun,22-Feb-2099 00:00:00 GMT)</param>
        /// <returns></returns>
        [DllImport("Wininet")]
        private static extern bool InternetSetCookie(string url, string name, string data);

        /// <summary>
        /// 从URL地址中提取域名
        /// </summary>
        /// <param name="url">URL地址(必须带http或https协议头)，例如：http://www.baidu.com/1.jpg </param>
        /// <param name="isReserveProtocolHead">是否保留协议头</param>
        /// <returns>返回带协议头或不带协议头的域名，例如：www.baidu.com或http://www.baidu.com</returns>
        public static string GetDomain(string url, bool isReserveProtocolHead)
        {
            int index1, index2;
            index1 = url.IndexOf("//") + 2;
            index2 = url.IndexOf("/", index1);
            string protocol = url.Substring(0, index1);
            string domain = index2 == -1 ? url.Substring(index1) : url.Substring(index1, index2 - index1);

            if (isReserveProtocolHead)
            {
                return protocol + domain;
            }
            {
                return domain;
            }
        }

        /// <summary>
        /// Cookie字符串转CookieCollection
        /// 注意：
        /// 通常cookieString中会包含多个cookie，多个cookie间用分号分割；
        /// 每个cookie以“key=value”的形式存在
        /// </summary>
        /// <param name="cookieString">Cookie字符串</param>
        /// <returns></returns>
        public static CookieCollection String2CookieCollection(string cookieString)
        {
            CookieCollection collection = new CookieCollection();

            string[] cookieArray = cookieString.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var cookieItem in cookieArray)
            {
                string[] items = cookieItem.Split('=');
                var name = items[0].Trim();
                var value = items[1].Trim();//name和value需要进行url编码

                collection.Add(new Cookie(name, value));
            }

            return collection;
        }

        /// <summary>
        /// CookieCollection转字符串
        /// </summary>
        /// <param name="cookies"></param>
        /// <returns></returns>
        public static string CookieCollection2String(CookieCollection cookies)
        {
            string result = string.Empty;

            foreach (Cookie cookie in cookies)
            {
                result += cookie.Name;
                result += "=";
                result += cookie.Value;
                result += ";";
            }

            return result;
        }

        /// <summary>
        /// 设置IE浏览器Cookie
        /// </summary>
        /// <param name="url">带http或https头的url地址</param>
        /// <param name="cookieString">cookie字符串，可以为用分号分割的cookie字符串</param>
        /// <returns>返回是否设置成功</returns>
        public static bool SetIECookie(string url, string cookieString)
        {
            bool isSuccess = true;

            CookieCollection cookies = PapdHelper.String2CookieCollection(cookieString);
            foreach (Cookie cookie in cookies)
            {
                isSuccess = PapdHelper.InternetSetCookie(PapdHelper.GetDomain(url, true), cookie.Name,
                    cookie.Value + ";expires=Sun,22-Feb-2099 00:00:00 GMT");
            }

            return isSuccess;
        } 
        #endregion

        /// <summary>
        /// 将Unix时间戳转换为本地时间
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static DateTime ConvertFromUnixTime(long milliseconds)
        {
            double ticks = milliseconds * Math.Pow(10, milliseconds.ToString().Length == 13 ? 4 : 7);
            TimeSpan timeSpan = new TimeSpan((long)ticks);
            DateTime utc = new DateTime(1970, 1, 1) + timeSpan;

            return utc.ToLocalTime();
        }
        #endregion

        public static long ConvertToUnixTimeInMilli(DateTime dt)
        {
            TimeSpan ts = dt.ToUniversalTime() - new DateTime(1970, 1, 1);

            return (long)(ts.Ticks/Math.Pow(10, 4));
        }
    }
}
