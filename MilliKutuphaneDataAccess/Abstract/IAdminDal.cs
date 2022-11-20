using MilliKutuphaneEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneDataAccess.Abstract
{
    public interface IAdminDal
    {
        bool CreateAdmin(Admin admin);

        User GetAdminByAdminName(string userName);
    }
}
