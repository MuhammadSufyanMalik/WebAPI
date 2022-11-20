using MilliKutuphaneEntities.Dtos.AdminRegisterDto;

namespace MilliKutuphaneBusiness.Abstract
{
    public interface IAdminService
    {
        
        bool CreateAdmin(AdminForRegisterDto adminForRegisterDto);

    }
}
