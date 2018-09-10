using ModelsData.FrameWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsData
{
    public class AccountModel
    {
        private SEDbContext context = null;
        public AccountModel()
        {
            context = new SEDbContext();
        }
        public bool Login(string UserName, string Passwprd)
        {
            object[] sqlParms =
            {
                new SqlParameter ("@Username",UserName),
                new SqlParameter("@PWD",Passwprd)
            };
            var res = context.Database.SqlQuery<bool>("sp_Login @Username,@PWD", sqlParms).SingleOrDefault();
            return res;
        }
    }
}
