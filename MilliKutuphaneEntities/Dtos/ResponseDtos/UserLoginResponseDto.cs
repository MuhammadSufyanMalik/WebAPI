using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneEntities.Dtos.ResponseDtos
{
    public class UserLoginResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string SchoolName { get; set; }
        public string StudentNumber { get; set; }
        public string Department { get; set; }
        public string token { get; set; }

    }
}
