using MilliKutuphaneEntities.Concrete;
using MilliKutuphaneEntities.Dtos;
using MilliKutuphaneEntities.Dtos.StudentUserDtos;

namespace MilliKutuphaneDataAccess.Abstract
{
    public interface IUserDal
    {
        bool CreateUser(User user);

        bool UpdateUser(StudentUserUpdateDto user);
        List<User> GetUsers();

        User GetUserById(int Id);
        User GetUserByUserName(string userName);

        List<User> GetUserByName(string Name);

        bool DeleteUserById(int Id);

        //  User GetUserByUserName(string name);

    }
}
