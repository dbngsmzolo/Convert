using Backend.Data.Ef.Repository;
using Backend.Data.Ef.Repository.Interfaces;
using Backend.Services.Services.Concrete;
using Backend.Services.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Services.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {

            services.AddScoped<IConvertRateService, ConvertRateService>();
            services.AddScoped<IConversionRateRepository, EfConversionRateRepository>();

            return services;
        }
    }
}
