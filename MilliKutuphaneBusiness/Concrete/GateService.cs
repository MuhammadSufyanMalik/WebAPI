using Core.Utilities.Results;
using MilliKutuphaneBusiness.Abstract;
using MilliKutuphaneDataAccess.Abstract;
using MilliKutuphaneEntities.Concrete;
using MilliKutuphaneEntities.Dtos.GatesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneBusiness.Concrete
{
    public class GateService : IGateService
    {
        private readonly IGatesDal _gatesDal;

        public GateService(IGatesDal gatesDal)
        {
            _gatesDal = gatesDal;

        }
        public IResult CreateGate(GatesDto gatesDto)
        {
            var existGateName = _gatesDal.GetGateByName(gatesDto.Name);
            if (existGateName != null)
            {
                return new ErrorResult("Gate Already Exist!");
            }

            var qrCode = Guid.NewGuid().ToString();
            var gates = new Gate()
            {
                CreatedTime = DateTime.Now,
                LastModifiedTime = DateTime.Now,
                Name = gatesDto.Name,
                Description = gatesDto.Description,
                QrCode = qrCode,
            };

            _gatesDal.CreateGate(gates);

            return new SuccessResult("Successfully Added");


        }

        public List<GatesDto> GetAllGates()
        {
            var gates = _gatesDal.GetAllGates();

            return gates.Select(g => new GatesDto()
            {
                Name = g.Name,
                Description= g.Description
            }).ToList();
        }

        public Gate GetGateByName(string Name)
        {
            return _gatesDal.GetGateByName(Name);
        }

        public IResult UpdateGate(GateUpdateDto gate)
        {
            var updatedGate = _gatesDal.UpdateGate(gate);
            if (updatedGate)
            {
                return new SuccessResult("Updated");
            }
            else
            {
                return new ErrorResult("Not updated");
            }
        }
    }
}
