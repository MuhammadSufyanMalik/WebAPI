using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneEntities.Dtos.StudentUserDtos
{
    public class StudentUserUpdateDto : StudentUserDto
    {
        public int  SchoolId { get; set; }
    }
}
