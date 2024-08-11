using AutoMapper;
using WellsFargo_BusinessEntities.ModelsDTO;
using WellsFargo_BusinessEntities.Entities;
namespace WellsFargo_Dapper.ServiceLayer.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeDTO>();
        }
    }

}
