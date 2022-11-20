using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilliKutuphaneBusiness.Abstract;
using MilliKutuphaneEntities.Concrete;
using MilliKutuphaneEntities.Dtos.GatesDto;

namespace MilliKutuphaneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatesController : ControllerBase
    {
        private readonly IGateService _gateService;

        public GatesController(IGateService gateService)
        {
            _gateService = gateService;
        }

        [HttpPost("createGates")]
        public IActionResult CreateGate([FromBody] GatesDto gatesDto)
        {
            var result = _gateService.CreateGate(gatesDto);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("UpdateGate")]
        public ActionResult UpdateGate([FromBody] GateUpdateDto gate)
        {
            var result = _gateService.UpdateGate(gate);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            { 
                return BadRequest(result);
            }

        }

        [HttpGet("GetAllGates")]
        public ActionResult GetAll()
        {
            return Ok(_gateService.GetAllGates());
        }
    }
}
