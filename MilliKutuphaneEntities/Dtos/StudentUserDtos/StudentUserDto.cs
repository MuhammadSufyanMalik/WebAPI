using MilliKutuphaneCore.BaseDtos;

namespace MilliKutuphaneEntities.Dtos
{
    public abstract class StudentUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string StudentNumber { get; set; }
        public string Department { get; set; }

    }
}
