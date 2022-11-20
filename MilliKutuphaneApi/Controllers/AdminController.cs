using Microsoft.AspNetCore.Mvc;
using MilliKutuphaneBusiness.Abstract;
using MilliKutuphaneEntities.Dtos.AdminRegisterDto;

namespace MilliKutuphaneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
       
        [HttpPost("createAdmin")]
        public  ActionResult CreateAdmin([FromBody] AdminForRegisterDto adminForRegisterDto)
        {
            var result = _adminService.CreateAdmin(adminForRegisterDto);

            if(result)
            {
               return Ok(result);
            }
            else
            {
                return BadRequest("Hata Oluştu or User already Exist");
            }
        }
    }
}
