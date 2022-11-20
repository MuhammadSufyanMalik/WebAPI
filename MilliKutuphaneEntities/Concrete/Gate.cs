using MilliKutuphaneCore.Entities;

namespace MilliKutuphaneEntities.Concrete
{
    public class Gate : BaseEntity
    {
        public Gate()
        {
            UserHistories = new List<UserHistory>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string QrCode { get; set; }

        public ICollection<UserHistory> UserHistories { get; set; }


    }
}
