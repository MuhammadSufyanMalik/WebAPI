using Core.Utilities.Results;
using MilliKutuphaneEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneBusiness.Abstract
{
    public interface IUserHistoryService
    {
        IResult CreateUserHistory(int UserId, string QrCode);

        IResult GetUserHistoryList(int Id);
    }
}
