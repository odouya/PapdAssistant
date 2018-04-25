using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PapdMonitor.Util
{
    public class AntiCode
    {
        /*
         * 使用方法：
         * 1.Load中
         * //载入识别库
           index = AntiCode.LoadCdsFromFile(Environment.CurrentDirectory + "\\ctthe.cds", "123");
         * 
         * 2.获取验证码函数
         * StringBuilder sb = new StringBuilder('\0', 256);
           if (AntiCode.GetVcodeFromBuffer(index, result.ResultByte, result.ResultByte.Length, sb))
               tbValidateCode.Text = sb.ToString();
           else
               lblValidateInfo.Text = "识别失败";
         */

        private static int cdsIndex = -1;

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            if (cdsIndex != -1)
                return;

            // 释放识别库文件
            string cdsFileName = System.IO.Path.GetTempPath() + Guid.NewGuid() + ".cds";
            Stream stream =
                System.Reflection.Assembly.GetEntryAssembly()
                    .GetManifestResourceStream("PapdMonitor.Resources.papd.cds");
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Close();
            System.IO.File.WriteAllBytes(cdsFileName, bytes);

            //载入识别库
            cdsIndex = AntiCode.LoadCdsFromFile(cdsFileName, "papd");
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="bufferImage">验证码图片字节数组</param>
        /// <returns></returns>
        public static string VerifyCode(byte[] bufferImage)
        {
            StringBuilder sb = new StringBuilder('\0', 256);
            if (GetVcodeFromBuffer(cdsIndex, bufferImage, bufferImage.Length, sb))
                return sb.ToString();
            return string.Empty;
        }

        [DllImport("AntiVC.dll")]
        public static extern int LoadCdsFromFile(string FilePath, string Password);

        [DllImport("AntiVC.dll")]
        public static extern int LoadCdsFromBuffer(byte[] FileBuffer, int FileBufLen, string Password);

        [DllImport("AntiVC.dll")]
        public static extern bool GetVcodeFromFile(int CdsFileIndex, string FilePath, StringBuilder Vcode);

        [DllImport("AntiVC.dll")]
        public static extern bool GetVcodeFromBuffer(int CdsFileIndex, byte[] FileBuffer, int ImgBufLen, StringBuilder Vcode);

        [DllImport("AntiVC.dll")]
        public static extern bool GetVcodeFromURL(int CdsFileIndex, string ImgURL, StringBuilder Vcode);

        [DllImport("urlmon.dll", EntryPoint = "URLDownloadToFileA")]
        public static extern int URLDownloadToFile(int pCaller, string szURL, string szFileName, int dwReserved, int lpfnCB);
    }
}
