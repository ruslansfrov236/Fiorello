using fiorello.business.Abstract;
using fiorello.business.Concrete;
using fiorello.data.Context;
using fiorello.entity.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace fiorello.business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessRegistration(this IServiceCollection services)
        {

          
            services.AddScoped<IHeaderService, HeaderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAppUserService, AppUserService>();


            
            services.AddScoped<IFileService, FileService>();
        }
    }
}
