using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TestCollection.Application.Services;
using TestCollection.Application.Services.Interfaces;
using TestCollection.Domain;
using TestCollection.Domain.Interfaces;

namespace TestCollection.IoC
{
    public class DependencyInjectionBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));


            services.AddScoped<ITestCollectionAppService, TestCollectionAppService>();
            services.AddScoped<ITestCollectionService, TestCollectionService>();
        }
    }
}
