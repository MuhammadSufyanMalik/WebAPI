using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneEntities.Dtos.SchoolDto
{
    public class SchoolListDto
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string SchoolTelephone { get; set; }
        public string SchoolCity { get; set; }
        public string SchoolCountry { get; set; }
        public int SchoolZipCode { get; set; }
        public string SchoolAddress { get; set; }
    }
}
