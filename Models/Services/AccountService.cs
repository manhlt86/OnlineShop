using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Services
{
    public class AccountService
    {
        private OnlineShopDbContext contex = null;

        public AccountService()
        {
            contex = new OnlineShopDbContext();
        }

        public bool Login(string userName, string password)
        {
            object[] sqlParams =
            {
                new SqlParameter("@UserName", userName),
                new SqlParameter("@Password", password)
            };
            bool res = contex.Database.SqlQuery<bool>("sp_Account_Login @UserName, @Password", sqlParams).SingleOrDefault();
            return res;
        }
    }
}
