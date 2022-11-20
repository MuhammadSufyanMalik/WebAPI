using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneEntities.Dtos.UserHistoryDtos
{
    public class UserHistoryListDto 
    {
        public string GateName { get; set; }
        public DateTime PassageWayTime { get; set; }
        public int EntranceType { get; set; }

    }
}
