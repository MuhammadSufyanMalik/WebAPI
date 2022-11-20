using Core.Utilities.Results;
using MilliKutuphaneBusiness.Abstract;
using MilliKutuphaneDataAccess.Abstract;
using MilliKutuphaneEntities.Concrete;
using MilliKutuphaneEntities.Dtos.SchoolDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilliKutuphaneBusiness.Concrete
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolDal _schoolDal;

        public SchoolService(ISchoolDal schoolDal)
        {
            _schoolDal = schoolDal;
        }

        public IResult CreateSchool(SchoolRegisterDto schoolRegisterDto)
        {
            var existSchoolName = _schoolDal.GetSchoolBySchoolName(schoolRegisterDto.SchoolName);
            if (existSchoolName != null) { return new ErrorResult("School Already Exist!"); }

            var school = new School()
            {
                SchoolName = schoolRegisterDto.SchoolName,
                SchoolTelephone = schoolRegisterDto.SchoolTelephone,
                SchoolCity = schoolRegisterDto.SchoolCity,
                SchoolCountry = schoolRegisterDto.SchoolCountry,
                SchoolZipCode = schoolRegisterDto.SchoolZipCode,
                SchoolAddress = schoolRegisterDto.SchoolAddress,


            };
           _schoolDal.CreateSchool(school);

            return new SuccessResult("Successfully Registered");
        }

        public IResult GetAllSchools()
        {
            List<SchoolListDto> schoolListDtos = new List<SchoolListDto>();
            var schools = _schoolDal.GetAllSchools();
            if(schools == null)
            {
                return new ErrorResult("Error!, No Schools Available!");
            }

            else
            {
                schoolListDtos = schools.Select(school => new SchoolListDto()
                {
                    Id = school.Id,
                    SchoolName = school.SchoolName,
                    SchoolTelephone = school.SchoolTelephone,
                    SchoolCity = school.SchoolCity,
                    SchoolZipCode = school.SchoolZipCode,
                    SchoolAddress = school.SchoolAddress,
                    SchoolCountry = school.SchoolCountry,
                }).ToList();
            }

            return new SuccessDataResult<List<SchoolListDto>>(schoolListDtos,"Success");
           

        }

        public School GetSchoolBySchoolName(string SchoolName)
        {
            var school = _schoolDal.GetSchoolBySchoolName(SchoolName);
            return school;
        }
    }
}
