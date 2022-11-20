using MilliKutuphaneCore.BaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneEntities.Dtos.AdminRegisterDto
{
    public class AdminForRegisterDto : BaseRegisterDto
    {
        public string IdentityNumber { get; set; }
        public string Designation { get; set; }
        public string TelephoneNumber { get; set; }
    }
}
