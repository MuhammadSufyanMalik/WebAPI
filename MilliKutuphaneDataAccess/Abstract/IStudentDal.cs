using MilliKutuphaneEntities.Concrete;

namespace MilliKutuphaneDataAccess.Abstract
{
    public interface IStudentDal
    {
        Student GetStudentById(int Id);
        bool CreateStudent(Student student);
        List<Student> GetStudents();

        List<Student> SearchStudentByName(string Name);

        Student GetStudentByUserName(string UserName);



    }
}
