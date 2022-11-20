using MilliKutuphaneDataAccess.Abstract;
using MilliKutuphaneEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneDataAccess.Concrete.EntityFramework
{
    public class EfUserQrCodeDal : IUserQrCodeDal
    {
        public bool CreateUserQrCode(UserQrCode userQrCode)
        {
            using(var context = new MilliKutuphaneContext())
            {
                context.UserQrCodes.Add(userQrCode);
                var result = context.SaveChanges();

                return result > 0;
            }
        }

        public UserQrCode GetUserQrCode(int Id)
        {
            using(var context =new MilliKutuphaneContext())
            {
                var result = context.UserQrCodes.Where(x => x.Id == Id).FirstOrDefault();

                return result;
            }
        }
    }
}
