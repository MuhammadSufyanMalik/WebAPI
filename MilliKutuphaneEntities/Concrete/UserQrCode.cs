using MilliKutuphaneCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneEntities.Concrete
{
    public class UserQrCode : BaseEntity
    {
        public string UserQrcode { get; set; }
        public User User { get; set; }
    }
}
