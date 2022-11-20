using Microsoft.EntityFrameworkCore;
using MilliKutuphaneDataAccess.Abstract;
using MilliKutuphaneEntities.Concrete;

namespace MilliKutuphaneDataAccess.Concrete.EntityFramework
{
    public class EfStudentDal : IStudentDal
    {
        public bool CreateStudent(Student student)
        {
            using (var context = new MilliKutuphaneContext())
            {
                context.Students.Add(student);
              //  context.Add<Student>(student);
                var result = context.SaveChanges();

                return result > 0;
            }
        }

        public Student GetStudentById(int Id)
        {
            using (var context = new MilliKutuphaneContext())
            {
                var student = context.Students.Include(x => x.User).Include(x=>x.School).Where(x => x.Id == Id).FirstOrDefault();

                return student;

            }
        }


        public List<Student> GetStudents()
        {
            using (var context = new MilliKutuphaneContext())
            {
                return context.Students.Include(x => x.User).Include(x=>x.School).ToList();
            }
        }

        public List<Student> SearchStudentByName(string Name)
        {
            using (var context = new MilliKutuphaneContext())
            {
                return context.Students.Include(x => x.User).Include(x => x.School).Where(x => x.User.FirstName.Contains(Name)).ToList();
            }
        }

        public Student GetStudentByUserName(string UserName)
        {
            using (var context = new MilliKutuphaneContext())
            {
                var student = context.Students.Include(x => x.User).Include(x => x.School).Where(x => x.User.Username == UserName).FirstOrDefault();

                return student;
            }
        }
    }
}
