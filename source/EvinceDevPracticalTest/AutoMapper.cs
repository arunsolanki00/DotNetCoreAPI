using AutoMapper;
using EvinceDev.Entity;
using EvinceDevPracticalTest.Models;

namespace EvinceDevPracticalTest
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Employee, EmployeeModel>();

            CreateMap<EmployeeModel, Employee>()
    .ForMember(dest => dest.OtherPhoneNumber,
                opt => opt.MapFrom(src => src.MobileNumber));

        }

    }
}
