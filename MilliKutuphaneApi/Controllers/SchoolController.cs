using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MilliKutuphaneBusiness.Abstract;
using MilliKutuphaneEntities.Dtos.SchoolDto;
using System.Security.Claims;

namespace MilliKutuphaneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpPost("CreateSchool")]
        public ActionResult CreateSchool([FromBody] SchoolRegisterDto schoolRegisterDto)
        {
            var result = _schoolService.CreateSchool(schoolRegisterDto);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetAllSchools")]
        public ActionResult GetAllSchools()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _schoolService.GetAllSchools();
            if (result.Success)
            { return Ok(result); }
            else
            { return BadRequest(result); }
            // return Ok(_schoolService.GetAllSchools());
        }
    }
}
