using MilliKutuphaneCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneEntities.Concrete
{
    public class UserHistory : BaseEntity
    {
        public int UserId { get; set; }

        public int GateId { get; set; }
        public DateTime PassageWayTime { get; set; }
        public int EntranceType { get; set; }

        public User User { get; set; }

        public Gate Gate { get; set; }

    }
}
