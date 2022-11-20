using MilliKutuphaneEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneDataAccess.Abstract
{
    public interface IUserQrCodeDal
    {
        bool CreateUserQrCode(UserQrCode userQrCode );

        UserQrCode GetUserQrCode(int Id);
    }
}
