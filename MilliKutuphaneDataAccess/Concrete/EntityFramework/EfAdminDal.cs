using MilliKutuphaneDataAccess.Abstract;
using MilliKutuphaneEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneDataAccess.Concrete.EntityFramework
{
    public class EfAdminDal : IAdminDal
    {
        public bool CreateAdmin(Admin admin)
        {
            using (var context = new MilliKutuphaneContext())
            {
               context.Admin.Add(admin);
                var result = context.SaveChanges();
                return result > 0;
            }
        }

        public User GetAdminByAdminName(string userName)
        {
            using (var context = new MilliKutuphaneContext())
            {
                var result = context.Users.SingleOrDefault(x => x.Username == userName);

                return result;
            }
        }
    }
}
