using MilliKutuphaneEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneDataAccess.Abstract
{
    public interface ISchoolDal
    {
        bool CreateSchool(School school);

        School GetSchoolBySchoolName(string SchoolName);

        List<School> GetAllSchools();
    }
}
