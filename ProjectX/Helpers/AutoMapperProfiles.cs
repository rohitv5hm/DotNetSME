using AutoMapper;
using ProjectX.Data.Entities;
using System;


namespace ProjectX.Helpers
{



    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddEmployeeDTO, Employee>().ReverseMap();
            CreateMap<AddDepartmentDTO, Department>();
        }


    }

}
