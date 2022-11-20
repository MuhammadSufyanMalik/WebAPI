using Microsoft.EntityFrameworkCore;
using MilliKutuphaneDataAccess.Abstract;
using MilliKutuphaneEntities.Concrete;
using MilliKutuphaneEntities.Dtos;
using MilliKutuphaneEntities.Dtos.StudentUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneDataAccess.Concrete.EntityFramework
{
    public class EfUserDal : IUserDal
    {
        public bool CreateUser(User user)
        {
            using (var context = new MilliKutuphaneContext())
            {
                context.Users.Add(user);
                var result = context.SaveChanges();

                return result > 0;
            }
        }


        public User GetUserById(int Id)
        {
            using (var context = new MilliKutuphaneContext())
            {
                var user = context.Users.Where(x => x.Id == Id).FirstOrDefault();

                return user;

            }

        }

        public List<User> GetUserByName(string Name)
        {
            using (var context = new MilliKutuphaneContext())
            {
                var user = context.Users.Where(x => x.FirstName.Contains(Name)).ToList();

                return user;

            }

        }

        public List<User> GetUsers()
        {
            using (var context = new MilliKutuphaneContext())
            {
                var result = context.Users.Include(s => s.Student).ToList();

                return result;
            }
        }

        public bool UpdateUser(StudentUserUpdateDto user)
        {
            using (var context = new MilliKutuphaneContext())
            {

                var existUser = context.Users.Where(x => x.Id == user.Id).FirstOrDefault();
          //      var student = context.Students.Where(x => x.Id == existUser.Id).FirstOrDefault();

                Student student = new Student();
                if (existUser != null)
                {
                    existUser.FirstName = user.Name;
                    existUser.LastName = user.LastName;
                    existUser.Email = user.Email;
                    existUser.LastModifiedTime = DateTime.Now;
                    existUser.TelephoneNumber= user.TelephoneNumber;
                    student.Id = existUser.Id;
                    student.StudentNumber = user.StudentNumber;
                    student.Department = user.Department;
                    student.SchoolId = user.SchoolId;


                }
                else
                {
                    return false;
                }


                context.Entry(existUser).State = EntityState.Modified;
                context.Entry(student).State = EntityState.Modified;
              
                var result = context.SaveChanges();

                return result > 0;

            }
        }

        public bool DeleteUserById(int id)
        {
            using (var context = new MilliKutuphaneContext())
            {

                var User = context.Users.Where(x => x.Id == id).FirstOrDefault();
                if (User != null)
                {
                    User.isDelete = true;
                }
                else
                {
                    return false;
                }

                context.Entry(User).State = EntityState.Modified;
                var result = context.SaveChanges();

                return result > 0;

            }
        }

        public User GetUserByUserName(string userName)
        {
            using (var context = new MilliKutuphaneContext())
            {
                var result = context.Users.FirstOrDefault(x => x.Username == userName);

                return result;
            }
        }
    }
}
