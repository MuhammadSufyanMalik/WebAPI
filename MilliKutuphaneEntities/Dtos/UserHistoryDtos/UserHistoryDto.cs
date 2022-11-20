using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneEntities.Dtos
{
    public class UserHistoryDto
    {
        public int UserId { get; set; }
        public int GateId { get; set; }
        public DateTime PassageWayTime { get; set; }
        public int EntranceType { get; set; }

    }
}
