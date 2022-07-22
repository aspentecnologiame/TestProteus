using AutoMapper;
using MarcosCosta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcosCosta.Service
{
    public class AutoMapperConfigurations
    {
        public static IMapper ChannelMapperConfig => ChannelMapperConfiguration();
        public static IMapper ItemMapperConfig => ItemMapperConfiguration();
        private static IMapper ChannelMapperConfiguration()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<channel, ChannelEntity>()
                .ForMember(dest => dest.Id, source => source.MapFrom(source => Guid.NewGuid()));
            });

            return mapperConfig.CreateMapper();
        }

        private static IMapper ItemMapperConfiguration()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<item, ItemEntity>();
                //.ForMember(dest => dest.About, source => source.MapFrom(source => source.about));
            });

            return mapperConfig.CreateMapper();
        }
    }
}
