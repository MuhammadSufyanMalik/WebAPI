using Microsoft.EntityFrameworkCore;
using MilliKutuphaneDataAccess.Abstract;
using MilliKutuphaneEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneDataAccess.Concrete.EntityFramework
{
    public class EfUserHistoryDal : IUserHistoryDal
    {
        public bool CreateUserHistory(UserHistory userHistory)
        {
            using (var context = new MilliKutuphaneContext())
            {
                context.UserHistory.Add(userHistory);
                var result = context.SaveChanges();
                return result > 0;
            }
        }

        public List<UserHistory> GetAllUserHistory(int userId)
        {
           using(var context = new MilliKutuphaneContext())
            {
                var userHistory = context.UserHistory.Include(x => x.Gate).Where(x => x.UserId == userId).ToList(); 
                
                return userHistory;
            }
        }

        public UserHistory GetUserHistory(int userId)
        {
            using (var context = new MilliKutuphaneContext())
            {
                var userHistory = context.UserHistory.Where(x => x.UserId == userId).OrderByDescending(x => x.PassageWayTime).FirstOrDefault();

                return userHistory;
            }
        }
    }
}
