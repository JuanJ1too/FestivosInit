
using Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extentions
{
    public static class ApplicationService
    {
        public static IServiceCollection ApplicationServiceConfigurator(this IServiceCollection service)
        {
            service.AddTransient<FestivoService>();
            return service;
        }
    }
}
