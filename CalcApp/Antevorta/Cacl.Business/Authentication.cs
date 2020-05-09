using Cacl.Business;
using Cacl.Business.Model;
using Cacl.Business.Request;
using Calc.Business.Interfaces;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

namespace Calc.Business
{
    public class Authentication : IAuthentication
    {
        private readonly string conString;
        public Authentication()
        {
            conString = Helper.GetConString("CalcDB");
        }
        public UserInfo GetUserInfo(UserRequest userRequest)
        {
            UserInfo UserInfo = null;
            using (IDbConnection connection = new SqlConnection(conString))
            {
                //var userInfoList = connection.Query<UserInfo>("select * from Users").AsList();
                var userInfoList = connection.Query<UserInfo>("GetUsers @paramUserName,@paramPwd", new { paramUserName = userRequest.UserName, paramPwd = userRequest.Password }).AsList();
                if (userInfoList != null && userInfoList.Count > 0)
                    UserInfo = userInfoList[0];
            }
            return UserInfo;
        }

        public List<UserInfo> GetUserInfos()
        {
            List<UserInfo> UserInfo = null;
            using (IDbConnection connection = new SqlConnection(conString))
            {
                UserInfo = connection.Query<UserInfo>("select * from Users").AsList();
                
            }
            return UserInfo;
        }
    }
}
