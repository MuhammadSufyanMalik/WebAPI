using Microsoft.AspNetCore.Mvc;
using MilliKutuphaneBusiness.Abstract;
using MilliKutuphaneCore.Utilities.Security;
using MilliKutuphaneEntities.Concrete;
using MilliKutuphaneEntities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace MilliKutuphaneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       
        
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
    
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Post([FromBody] UserForLoginDto userForLoginDto)
        {
            var result = _userService.UserLogin(userForLoginDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("Register")]
        public ActionResult Create([FromBody] UserForRegisterDto userForRegisterDto)
        {
            var result = _userService.CreateUser(userForRegisterDto);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


    }
}
