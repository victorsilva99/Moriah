using AutoMapper;
using Moriah.Application.AutoMapper;

namespace Moriah.Web.Middlewares
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
