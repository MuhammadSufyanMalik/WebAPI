using Core.Utilities.Results;
using MilliKutuphaneEntities.Concrete;
using MilliKutuphaneEntities.Dtos.SchoolDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneBusiness.Abstract
{
    public interface ISchoolService
    {
        IResult CreateSchool(SchoolRegisterDto schoolRegisterDto);

        School GetSchoolBySchoolName(string SchoolName);

        IResult GetAllSchools();
    }
}
