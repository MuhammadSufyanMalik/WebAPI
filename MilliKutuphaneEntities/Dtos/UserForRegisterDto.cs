using MilliKutuphaneCore.BaseDtos;

namespace MilliKutuphaneEntities.Dtos
{
    public class UserForRegisterDto : BaseRegisterDto
    {

        public int SchoolId { get; set; }
        public string StudentNumber { get; set; }
        public string Department { get; set; }
    }
}
