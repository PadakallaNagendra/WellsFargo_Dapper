using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WellsFargo_Dapper.ServiceLayer.AutoMapper;

namespace WellsFargo_Dapper_ServiceLayer

{
    public static class AutoMapperConfig
    {
        public static void InitializeMap(IServiceCollection services)
        {
            //Initialize all AutoMapper profiles
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<AutoMapperProfile>();


            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}


