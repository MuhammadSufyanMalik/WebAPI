using Core.Utilities.Results;
using MilliKutuphaneEntities.Concrete;
using MilliKutuphaneEntities.Dtos;
using MilliKutuphaneEntities.Dtos.StudentUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneBusiness.Abstract
{
    public interface IUserService
    {
      //  List<StudentUserDto> GetStudentsList();
        IResult GetStudentsList();
        IResult CreateUser(UserForRegisterDto userForRegisterDto);

        IResult UpdateUser(StudentUserUpdateDto user);

      //  StudentUserDto GetUserById(int Id);
        IResult GetUserById(int Id);

        User GetUserByUsername(string userName);

        IResult UserLogin(UserForLoginDto userForLoginDto);
        IResult DeleteUserById(int Id);

      //  List<StudentUserDto> SearchStudentByName(string Name);
        IResult SearchStudentByName(string Name);

        IResult GetUserQrCode(int Id);


    }
}
