using MilliKutuphaneDataAccess.Abstract;
using MilliKutuphaneEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneDataAccess.Concrete.EntityFramework
{
    public class EfSchoolDal : ISchoolDal
    {
        public bool CreateSchool(School school)
        {
            using (var context = new MilliKutuphaneContext())
            {
                context.Schools.Add(school);
                var result = context.SaveChanges();

                return result > 0;
            }
        }

        public List<School> GetAllSchools()
        {
           using(var context = new MilliKutuphaneContext())
            {
                var result = context.Schools.ToList();
                return result;
            }
        }

        public School GetSchoolBySchoolName(string SchoolName)
        {
            using (var context = new MilliKutuphaneContext())
            {
                var result = context.Schools.FirstOrDefault(school => school.SchoolName.Trim().ToLower() == SchoolName.Trim().ToLower());

                return result;
            }
        }
    }
}
