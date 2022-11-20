using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MilliKutuphaneBusiness.Abstract;
using MilliKutuphaneEntities.Dtos;
using System.Security.Claims;

namespace MilliKutuphaneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserHistoryController : ControllerBase
    {
        
        private readonly IUserHistoryService _userHistoryService;

        public UserHistoryController(IUserHistoryService userHistoryService)
        {
            _userHistoryService = userHistoryService;
        }
    

        [HttpPost("CreateUserHistory")]
        public ActionResult CreateUserHistory(string Qrcode)
        {
            int UserId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = _userHistoryService.CreateUserHistory(UserId,Qrcode);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetUserHistoryByUserId")]
        public ActionResult GetUserHistoryById() {
            int UserId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var result = _userHistoryService.GetUserHistoryList(UserId);

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
