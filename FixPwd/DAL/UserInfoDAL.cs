using FixPwd.Model;
using FixPwd.DBHelper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixPwd.DAL
{
    public class UserInfoDAL
    {
        SQLHelper sqlHelp = new SQLHelper();
        public int UserQuery(UserInfo user)
        {
            int i = Convert.ToInt32(sqlHelp.ExecuteScalar("select count(*) from userinfo where UserName=@UserName and Pwd=@password",
                 new SqlParameter("@UserName", user.userName),
                  new SqlParameter("@password", user.password)));
            return i;
        }
        public void PwdFix(UserInfo user)
        {
            sqlHelp.ExecuteNonQuery(@"UPDATE userinfo SET Pwd=@password where UserName=@UserName",
                new SqlParameter("@UserName", user.userName),
                new SqlParameter("@password", user.password));
        }
        public int UserTel(UserInfo user)
        {
            int i = (int)sqlHelp.ExecuteScalar("select count(*) from userinfo where UserName=@UserName and Tel=@tel",
                 new SqlParameter("@UserName", user.userName),
                  new SqlParameter("@Tel", user.tel));
            return i;
        }
    }
}
