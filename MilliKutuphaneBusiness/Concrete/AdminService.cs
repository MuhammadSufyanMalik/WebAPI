using MilliKutuphaneBusiness.Abstract;
using MilliKutuphaneCore.Utilities.Security;
using MilliKutuphaneDataAccess.Abstract;
using MilliKutuphaneEntities.Concrete;
using MilliKutuphaneEntities.Dtos.AdminRegisterDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneBusiness.Concrete
{
    public class AdminService : IAdminService
    {
        private readonly IAdminDal _adminDal;
        private readonly IUserDal _userDal;

        public AdminService(IAdminDal adminDal, IUserDal userDal)
        {
            _adminDal = adminDal;
            _userDal = userDal;
        }

        public bool CreateAdmin(AdminForRegisterDto adminForRegisterDto)
        {
            var exist = _userDal.GetUserByUserName(adminForRegisterDto.Username);
            if (exist != null) { return false; }

            var user = new User()
            {
                Username = adminForRegisterDto.Username,
                FirstName = adminForRegisterDto.FirstName,
                LastName = adminForRegisterDto.LastName,
                Email = adminForRegisterDto.Email,
                IdentityNumber =adminForRegisterDto.IdentityNumber,
                TelephoneNumber = adminForRegisterDto.TelephoneNumber,
                LastModifiedTime = DateTime.Now,
                CreatedTime = DateTime.Now,
            };
                byte[] passwordHash, PasswordSalt;
            HashingHelper.CreatePasswordHash(adminForRegisterDto.Password, out passwordHash, out PasswordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = PasswordSalt;
            var result = _userDal.CreateUser(user);

            var admin = new Admin()
            {
                Id = user.Id, 
                Designation = adminForRegisterDto.Designation, 

            };
            _adminDal.CreateAdmin(admin);

            return result;
            

        }
    }
}
