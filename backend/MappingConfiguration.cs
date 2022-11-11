using APIBackend.Dto;
using APIBackend.Models;
using AutoMapper;

namespace APIBackend
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            { 
                configuration.CreateMap<EnterpriseDto, Enterprise>();
                configuration.CreateMap<Enterprise, EnterpriseDto>();
            });
            return mapperConfiguration;
        }
    }
}
