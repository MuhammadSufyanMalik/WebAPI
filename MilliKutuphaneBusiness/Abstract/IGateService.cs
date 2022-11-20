using Core.Utilities.Results;
using MilliKutuphaneEntities.Concrete;
using MilliKutuphaneEntities.Dtos.GatesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneBusiness.Abstract
{
    public interface IGateService
    {
        IResult CreateGate(GatesDto gatesDto);

        IResult UpdateGate(GateUpdateDto gate);

        Gate GetGateByName(string Name);

        List<GatesDto> GetAllGates();
    }

}
