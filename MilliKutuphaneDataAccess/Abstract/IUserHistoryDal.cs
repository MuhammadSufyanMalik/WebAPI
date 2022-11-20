using MilliKutuphaneEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneDataAccess.Abstract
{
    public interface IUserHistoryDal
    {
        bool CreateUserHistory(UserHistory userHistory);

        List<UserHistory> GetAllUserHistory(int userId);

        UserHistory GetUserHistory(int userId);
    }
}
