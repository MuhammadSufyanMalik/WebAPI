using MilliKutuphaneCore.Entities;

namespace MilliKutuphaneEntities.Concrete
{
    public class Student : BaseEntity
    {
 
        public int SchoolId { get; set; }
        public string StudentNumber { get; set; }
        public string Department { get; set; }
        public User User { get; set; }
        public School School { get; set; }

  
    }
}
