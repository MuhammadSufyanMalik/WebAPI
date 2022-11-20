using Core.Utilities.Results;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MilliKutuphaneBusiness.Abstract;
using MilliKutuphaneCore.Utilities.Security;
using MilliKutuphaneDataAccess.Abstract;
using MilliKutuphaneEntities.Concrete;
using MilliKutuphaneEntities.Dtos;
using MilliKutuphaneEntities.Dtos.ResponseDtos;
using MilliKutuphaneEntities.Dtos.StudentUserDtos;
using MilliKutuphaneEntities.Dtos.UserQrCodeDtos;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MilliKutuphaneBusiness.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IStudentDal _studentDal;
        private readonly IUserQrCodeDal _userQrCodeDal;
        
        private readonly IConfiguration _configuration;
        public UserService(IUserDal userDal, IStudentDal studentDal, IUserQrCodeDal userQrCodeDal, IConfiguration configuration)
        {
            _userDal = userDal;
            _studentDal = studentDal;
            _userQrCodeDal = userQrCodeDal;
            _configuration = configuration;

        }
        public IResult CreateUser(UserForRegisterDto userForRegisterDto)
        {
            var exist = _userDal.GetUserByUserName(userForRegisterDto.Username);
            if (exist != null) { return new ErrorResult("User Already Exist!"); }

            var user = new User()
            {
                
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Username = userForRegisterDto.Username,
                Email = userForRegisterDto.Email,
                IdentityNumber = userForRegisterDto.IdentityNumber,
                TelephoneNumber = userForRegisterDto.TelephoneNumber,
                CreatedTime = DateTime.Now,
                LastModifiedTime = DateTime.Now,

                PasswordHash = new byte[0],
                PasswordSalt = new byte[0]
            };
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            var result = _userDal.CreateUser(user);

            var student = new Student()
            {
                Id = user.Id,
                SchoolId = userForRegisterDto.SchoolId,
                Department = userForRegisterDto.Department,
                StudentNumber = userForRegisterDto.StudentNumber,

            };

            _studentDal.CreateStudent(student);

            var userQrcode = new UserQrCode()
            {
                Id = user.Id,
                UserQrcode = Guid.NewGuid().ToString(),

            };

            _userQrCodeDal.CreateUserQrCode(userQrcode);

            return new SuccessResult("Successfully Registered");
        }

        public IResult DeleteUserById(int Id)
        {

            var deletedUser = _userDal.DeleteUserById(Id); ;

            if (deletedUser)
            {
                return new SuccessResult("User Deleted");
            }
            else
            {
                return new ErrorResult("No User found for given Id");
            }

        }

        public IResult GetUserById(int Id)
        {
            StudentUserListDto studentUserForListDto = new StudentUserListDto();
            var student = _studentDal.GetStudentById(Id);

            if (student == null)
            {
                // return new StudentUserDto();

                return new ErrorResult("Error, Not a Student");
            }
            else
            {
                studentUserForListDto.Id = student.Id;
                studentUserForListDto.Name = student.User.FirstName;
                studentUserForListDto.LastName = student.User.LastName;
                studentUserForListDto.Email = student.User.Email;
                studentUserForListDto.StudentNumber = student.StudentNumber;
                studentUserForListDto.Department = student.Department;
                studentUserForListDto.SchoolName = student.School.SchoolName;
                studentUserForListDto.IdentityNumber = student.User.IdentityNumber;
                studentUserForListDto.TelephoneNumber = student.User.TelephoneNumber;

                return new SuccessDataResult<StudentUserListDto>(studentUserForListDto, "Success");
            }

        }

        public IResult SearchStudentByName(string Name)
        {

            //    var user = _userDal.GetUserByName(Name);
            List<StudentUserListDto> studentUserDto = new List<StudentUserListDto>();

            var students = _studentDal.SearchStudentByName(Name);
            if (students.Count == 0)
            {
                return new ErrorResult("Error, No any Student found with the given name!");
            }

            else
            {
                studentUserDto = students.Select(x => new StudentUserListDto()
                {
                    Email = x.User.Email,
                    Id = x.User.Id,
                    LastName = x.User.LastName,
                    Name = x.User.FirstName,
                    Department = x.Department,
                    StudentNumber = x.StudentNumber,
                    SchoolName = x.School.SchoolName,
                    TelephoneNumber = x.User.TelephoneNumber,
                    IdentityNumber = x.User.IdentityNumber
                    
                }).ToList();

                return new SuccessDataResult<List<StudentUserListDto>>(studentUserDto, "Success");
            }

        }

        public User GetUserByUsername(string userName)
        {
            var user = _userDal.GetUserByUserName(userName);

            return user;
        }



        public IResult UpdateUser(StudentUserUpdateDto user)
        {

            var updatedUser = _userDal.UpdateUser(user);

            if (updatedUser)
            {
                return new SuccessResult("Updated");
            }
            else
            {
                return new ErrorResult("Not updated");
            }
        }

        public IResult GetStudentsList()
        {
            List<StudentUserListDto> studentUserDto = new List<StudentUserListDto>();


            var users = _studentDal.GetStudents();

            if (users == null)
            {
                return new ErrorResult("Error, Not a Student");
            }

            else
            {
                studentUserDto = users.Select(x => new StudentUserListDto()
                {
                    Email = x.User.Email,
                    Id = x.User.Id,
                    LastName = x.User.LastName,
                    Name = x.User.FirstName,
                    Department = x.Department,
                    StudentNumber = x.StudentNumber,
                    SchoolName = x.School.SchoolName,
                    TelephoneNumber =x.User.TelephoneNumber,
                    IdentityNumber = x.User.IdentityNumber,

                }).ToList();



                return new SuccessDataResult<List<StudentUserListDto>>(studentUserDto, "Success");
            }

        }

        public IResult UserLogin(UserForLoginDto userForLoginDto)
        {
            var user = GetUserByUsername(userForLoginDto.UserName);
            if (user == null)
            {
                return new ErrorResult("User Not Found");
            }

            else
            {
                if (HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))

                {
                    string token = CreateToken(user);
                    UserLoginResponseDto studentReponse = new UserLoginResponseDto();
                    var student = _studentDal.GetStudentByUserName(userForLoginDto.UserName);
                    if (student != null)
                    {
                        studentReponse.token = token;
                        studentReponse.Id = student.Id;
                        studentReponse.Name = student.User.FirstName;
                        studentReponse.LastName = student.User.LastName;
                        studentReponse.Email = student.User.Email;
                        studentReponse.StudentNumber = student.StudentNumber;
                        studentReponse.SchoolName = student.School.SchoolName;
                        studentReponse.Department = student.Department;
                        studentReponse.IdentityNumber = student.User.IdentityNumber;
                        studentReponse.TelephoneNumber = student.User.TelephoneNumber;

                        return new SuccessDataResult<UserLoginResponseDto>(studentReponse, "Success");

                    }

                    else
                    {
                        return new ErrorResult("!Error, Not a Student");
                    }
                }

                else
                {
                    return new ErrorResult("Incorrect userName or Password");
                }

            }




        }

        private string CreateToken(User user)
        {
            try
            {
                List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public IResult GetUserQrCode(int Id)
        {
            UserQrCodeDto userQrCodeDto = new UserQrCodeDto();

            var userQrCode = _userQrCodeDal.GetUserQrCode(Id);

            if (userQrCode != null)
            {
                userQrCodeDto.UserQrCode = userQrCode.UserQrcode;
                
                return new SuccessDataResult<UserQrCodeDto>(userQrCodeDto,"Success");

            }
            else
            {
                return new ErrorResult("No QrCode exist against this User");
            }
           
        }
    }

}
