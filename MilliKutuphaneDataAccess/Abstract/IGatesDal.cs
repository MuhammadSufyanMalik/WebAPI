using MilliKutuphaneEntities.Concrete;
using MilliKutuphaneEntities.Dtos.GatesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneDataAccess.Abstract
{
    public interface IGatesDal
    {
        bool CreateGate(Gate gate);

        bool UpdateGate(GateUpdateDto gate);

        Gate GetGateByName(String Name);

        Gate GetGateByQrCode(String QrCode);

        List<Gate> GetAllGates();
    }
}
