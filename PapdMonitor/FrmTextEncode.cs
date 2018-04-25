using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace PapdMonitor
{
    public partial class FrmTextEncode : FrmBase
    {
        public string SourceString;

        public FrmTextEncode()
        {
            InitializeComponent();
        }

        private void FrmTextEncode_Shown(object sender, EventArgs e)
        {
            // 初始化源码文本框
            this.textBox1.Text = this.SourceString;
            // 初始化下拉框
            this.comboBox1.Items.Add(new EncodeFunc("MD5", EncodeByMD5));
            this.comboBox1.Items.Add(new EncodeFunc("SHA1", EncodeBySHA1));
            this.comboBox1.Items.Add(new EncodeFunc("RSA", EncodeByRSA));
            this.comboBox1.SelectedIndexChanged += ComboBox1OnSelectedIndexChanged;
            this.comboBox1.SelectedIndex = 0;
        }

        private void ComboBox1OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length < 1)
                return;
            var encodeFunc = this.comboBox1.SelectedItem as EncodeFunc;
            if (encodeFunc != null)
            {
                this.textBox2.Text = encodeFunc.Encode(this.textBox1.Text);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ComboBox1OnSelectedIndexChanged(this.comboBox1, new EventArgs());
        }

        private string EncodeByMD5(string str)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str));

            return BitConverter.ToString(data).Replace("-","").ToLower();
        }

        private string EncodeBySHA1(string str)
        {
            System.Security.Cryptography.SHA1CryptoServiceProvider sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] data = sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str));

            return Convert.ToBase64String(data);
        }

        private string EncodeByRSA(string str)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择证书";
            ofd.Filter = "pfx证书(*.pfx)|*.pfx";
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return string.Empty;

            //1.读取证书中的私钥
            //2.计算sha1值
            //3.证书私钥->rsa->rsaformatter->对sha1值签名

            string pfxPrivateKey;
            System.Security.Cryptography.X509Certificates.X509Certificate2 x509 = new System.Security.Cryptography.X509Certificates.X509Certificate2(ofd.FileName, "110110", X509KeyStorageFlags.Exportable);
            pfxPrivateKey = x509.PrivateKey.ToXmlString(true);

            Console.WriteLine(pfxPrivateKey);

            System.Security.Cryptography.SHA1CryptoServiceProvider sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] hashResult = sha1.ComputeHash(System.Text.Encoding.ASCII.GetBytes(str));

            System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider();
            rsa.FromXmlString(pfxPrivateKey);

            System.Security.Cryptography.RSAPKCS1SignatureFormatter formatter = new RSAPKCS1SignatureFormatter(rsa);
            formatter.SetHashAlgorithm("sha1");
            byte[] data = formatter.CreateSignature(hashResult);

            return Convert.ToBase64String(data);
        }
    }

    class EncodeFunc
    {
        public EncodeFunc(string name, Func<string,string> encode)
        {
            this.Name = name;
            this.Encode = encode;
        }

        public string Name;
        public Func<string, string> Encode;

        public override string ToString()
        {
            return this.Name;
        }
    }
}
