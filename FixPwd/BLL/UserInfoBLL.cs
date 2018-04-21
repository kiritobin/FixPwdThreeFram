using FixPwd.DAL;
using FixPwd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixPwd.BLL
{
    public class UserInfoBLL
    {
        UserInfoDAL userInfoDal = new UserInfoDAL();
        public int Query(UserInfo user)
        {
            int count = userInfoDal.UserQuery(user);
            return count;
        }
        public void Fix(UserInfo user)
        {
            userInfoDal.PwdFix(user);
        }
        public bool ResetPwd(UserInfo user)
        {
            int count = userInfoDal.UserTel(user);
            if (count>0)
            {
                user.password = "666666";
                userInfoDal.PwdFix(user);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
