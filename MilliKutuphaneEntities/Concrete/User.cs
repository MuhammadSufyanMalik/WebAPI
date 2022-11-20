using MilliKutuphaneCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneEntities.Concrete
{
    public class User: BaseEntity
    {
        public User()
        {
             UserHistories = new List<UserHistory>();
            
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string IdentityNumber { get; set; }
        public string TelephoneNumber { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Student? Student { get; set; }

        public Admin? Admin { get; set; }

        public UserQrCode? UserQrCode { get; set; }
        public ICollection<UserHistory> UserHistories { get; set; }

    }
}
