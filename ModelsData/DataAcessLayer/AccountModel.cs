using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsData.Framework;
namespace ModelsData
{
    public class AccountModel
    {
        private SEDbContext context = null;
        public AccountModel()
        {
            context = new SEDbContext();
        }

        public long Insert(tblUser entity)
        {
            context.tblUsers.Add(entity);
            context.SaveChanges();
            return entity.ID;
        }

        public tblUser GetById(string username)
        {
            return context.tblUsers.SingleOrDefault(x => x.UserName == username);
        }
        public int Login(string Username, string Passwprd)
        {
            var result = context.tblUsers.SingleOrDefault(x => x.UserName == Username);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;

                }
                else
                {
                    if (result.PWD == Passwprd)
                        return 1;
                    else
                        return -2;
                }
            }

            //object[] sqlParms =
            //{
            //    new SqlParameter ("@Username",Username),
            //    new SqlParameter("@PWD",Passwprd)
            //};
            //var res = context.Database.SqlQuery<bool>("sp_Login @Username,@PWD", sqlParms).SingleOrDefault();
            //return res;
        }
    }
}
