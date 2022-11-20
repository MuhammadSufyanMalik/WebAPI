using Core.Utilities.Results;
using MilliKutuphaneBusiness.Abstract;
using MilliKutuphaneCore.Utilities.Enums;
using MilliKutuphaneDataAccess.Abstract;
using MilliKutuphaneEntities.Concrete;
using MilliKutuphaneEntities.Dtos;
using MilliKutuphaneEntities.Dtos.UserHistoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneBusiness.Concrete
{
    public class UserHistoryService : IUserHistoryService
    {
        private readonly IUserHistoryDal _userHistoryDal;
        private readonly IUserDal _userDal;
        private readonly IGatesDal _gatesDal;

        public UserHistoryService(IUserHistoryDal userHistoryDal, IUserDal userDal, IGatesDal gatesDal)
        {
            _userHistoryDal = userHistoryDal;
            _userDal = userDal;
            _gatesDal = gatesDal;
        }

        public IResult CreateUserHistory(int UserId, string QrCode)
        {
            int entranceType;
            try
            {
                var gate = _gatesDal.GetGateByQrCode(QrCode);
                if (gate == null)
                {
                    return new ErrorResult("No Such Door Exist");
                }

                var existUser = _userDal.GetUserById(UserId);

                if (existUser != null)
                {
                    var entranceTypeResult = _userHistoryDal.GetUserHistory(UserId);
                    if (entranceTypeResult != null)
                    {
                        if (entranceTypeResult.EntranceType == (int)EEntranceTypes.Exit)
                        {
                            entranceType = (int)EEntranceTypes.Enter; // Need to create Enums for these
                        }
                        else { entranceType = (int)EEntranceTypes.Exit; }
                    }
                    else
                    {
                        entranceType = (int)EEntranceTypes.Enter;
                    }

                    var userHistory = new UserHistory()
                    {
                        UserId = UserId,
                        GateId = gate.Id,
                        PassageWayTime = DateTime.Now,
                        EntranceType = entranceType, // 1 for Enter 0 for Exit
                        CreatedTime = DateTime.Now,
                        LastModifiedTime = DateTime.Now,

                    };
                    _userHistoryDal.CreateUserHistory(userHistory);

                    return new SuccessResult("History Added, Successfully");
                }

                else
                {
                    return new ErrorResult("User Dosen't Exist");
                }
            }
            catch (Exception ex)
            {

                return new ErrorResult("Error: " + ex.Message + "InnerException:" + ex.InnerException);
            }

        }


        public IResult GetUserHistoryList(int Id)
        {
            List<UserHistoryListDto> userHistoryListDto = new List<UserHistoryListDto>();

            var userHistory = _userHistoryDal.GetAllUserHistory(Id);

            if (userHistory.Count == 0)
            { return new ErrorResult("No User History Found!"); }
            else
            {
                userHistoryListDto = userHistory.Select(x => new UserHistoryListDto()
                {
                    GateName = x.Gate.Name,
                    EntranceType = x.EntranceType,
                    PassageWayTime = x.PassageWayTime,
                }).ToList();

                return new SuccessDataResult<List<UserHistoryListDto>>(userHistoryListDto, "Success");
            }
        }
    }
}
