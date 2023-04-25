using Microsoft.EntityFrameworkCore;
using Moriah.Infra.Data.Context;

namespace Moriah.Web.Extensions;

public static class DbExtension
{
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MoriahDataContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SQLServer"));
        });
    }
}