using Microsoft.EntityFrameworkCore;
using MilliKutuphaneDataAccess.Abstract;
using MilliKutuphaneEntities.Concrete;
using MilliKutuphaneEntities.Dtos.GatesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneDataAccess.Concrete.EntityFramework
{
    public class EfGatesDal : IGatesDal
    {
        public bool CreateGate(Gate gate)
        {
           using(var context = new MilliKutuphaneContext())
            {
                context.Gates.Add(gate);
                var result = context.SaveChanges();

                return result > 0;
            }
        }

        public Gate GetGateByName(string Name)
        {
            using (var context = new MilliKutuphaneContext())
            {
                var result = context.Gates.FirstOrDefault(g => g.Name == Name);

                return result;
            }
        }

        public List<Gate> GetAllGates()
        {
            using (var context = new MilliKutuphaneContext())
            {
                return context.Gates.ToList();
            }
        }

        public bool UpdateGate(GateUpdateDto gate)
        {
            using (var context = new MilliKutuphaneContext())
            {
                var existgate = context.Gates.FirstOrDefault(g => g.Id == gate.Id);

               
                if(existgate != null)
                {
                    existgate.Name = gate.Name;
                    existgate.Id = gate.Id;
                    existgate.Description = gate.Description;
                    existgate.QrCode = existgate.QrCode;

                }

                else
                {
                    return false;
                }

                context.Entry(existgate).State = EntityState.Modified;
                var result = context.SaveChanges();

                return result > 0;

            }
        }

        public Gate GetGateByQrCode(string QrCode)
        {
            using (var context = new MilliKutuphaneContext())
            {
                var result = context.Gates.FirstOrDefault(g => g.QrCode == QrCode);

                return result;
            }
        }
    }
}
