using Moriah.Application.AppServices;
using Moriah.Application.Interfaces;
using Moriah.Domain.Interfaces.Repositories;
using Moriah.Domain.Interfaces.Services;
using Moriah.Domain.Services;
using Moriah.Infra.Data.Repositories;

namespace Moriah.Web.Middlewares
{
    public static class DependenciesMiddleware
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // service
            services.AddScoped<ICaixaService, CaixaService>();

            // application
            services.AddScoped<ICaixaAppService, CaixaAppService>();

            // data
            services.AddScoped<ICaixaRepository, CaixaRepository>();
        }
    }
}
