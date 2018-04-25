using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DotNet.Utilities
{
    class AntiCode
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
