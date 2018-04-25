using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PapdLib.Info
{
    public class UserInfo
    {
        public long id;
        public int birthday;
        public double weight;
        public double height;
        public string nick;
        public string gender;
        public int credits;
        public int wanliCredits;
        public string avatar;
        public string mobile;

        /// <summary>
        /// 获取头像URL
        /// </summary>
        /// <returns></returns>
        public string GetAvatarUrl()
        {
            return PapdHelper.GetImageUrl(this.avatar);
        }

        public string GetGender()
        {
            return this.gender == "MALE" ? "男" : "女";
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("ID：" + this.id);
            builder.AppendLine("用户名：" + this.nick);
            builder.AppendLine("性别：" + this.GetGender());
            builder.AppendLine("手机号：" + this.mobile);

            return builder.ToString();
        }
    }
}
