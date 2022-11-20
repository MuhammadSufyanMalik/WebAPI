using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilliKutuphaneBusiness.Abstract;
using MilliKutuphaneEntities.Dtos.StudentUserDtos;
using System.Security.Claims;

namespace MilliKutuphaneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /* [HttpPost("login")]
         public IActionResult Post([FromBody] UserForLoginDto userForLoginDto)
         {
             var user = _userService.GetUserByUsername(userForLoginDto.UserName);
             if (user == null)
             {
                 return NotFound("User not found");
             }
             else
             {
                 if (HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
                 {
                     return Ok("Login Successfully");
                 }
                 else
                 {
                     return BadRequest("Hatalı kullanıcı adı veya şifre");
                 }
             }
         }*/

        [HttpGet("getAllStudents"),]
        public ActionResult GetAll()
        {
            var result = _userService.GetStudentsList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        /* [HttpPost("create")]
         public ActionResult Create([FromBody] UserForRegisterDto userForRegisterDto)
         {
             var result = _userService.CreateUser(userForRegisterDto);

             if (result)
             {
                 return Ok("Kayıt işlemi başarılı");
             }
             else
             {
                 return BadRequest("Hata Oluştu or User already Exist");
             }
         }*/

        [HttpPost("Update")]
        public ActionResult Update([FromBody] StudentUserUpdateDto user)
        {
            var result = _userService.UpdateUser(user);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetUserById")]
        public ActionResult GetByUserId(int userId)
        {
            var result = _userService.GetUserById(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("SearhStudentByName")]
        public ActionResult SearchStudentByName(string Name)
        {
            var result = _userService.SearchStudentByName(Name);


            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("DeleteByUserId")]
        public ActionResult DeleteByUserId(int userId)
        {
            var result = _userService.DeleteUserById(userId);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetUserQrCode")]
        public ActionResult GetUserQrCode()
        {
            int UserId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = _userService.GetUserQrCode(UserId);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            { return BadRequest(result); }
        }

    }
}
