using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapdLib
{
    public class PajkMethods
    {
        public static readonly PajkMethods UserRenewUserToken = new PajkMethods("user.renewUserToken");
        public static readonly PajkMethods UserRenewUserTokenAndWebToken = new PajkMethods("user.renewUserTokenAndWebToken");
        public static readonly PajkMethods UserGetWebToken = new PajkMethods("user.getWebUserToken");
        public static readonly PajkMethods UserLogout = new PajkMethods("user.logout");
        public static readonly PajkMethods UserQQLogin = new PajkMethods("user.qqLogin");
        public static readonly PajkMethods UploadWalkData = new PajkMethods("healthcenter.saveOrUpdateBatchPersonalWalkData");
        public static readonly PajkMethods DownloadWalkData = new PajkMethods("healthcenter.getPersonalWalkData");

        public string MethodName { get; private set; }

        private PajkMethods(string methodName)
        {
            this.MethodName = methodName;
        }

        public override string ToString()
        {
            return this.MethodName;
        }
    }
}
