using FluentValidation;
using FluentValidation.AspNetCore;
using Moriah.Application.ViewModels;

namespace Moriah.Web.Extensions;

public static class FluentValidationExtension
{
    public static void RegisterAllValidators(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        
        services.AddValidatorsFromAssemblyContaining<CaixaViewModel>();
    }
}