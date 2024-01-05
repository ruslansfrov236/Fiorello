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

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.User.RequireUniqueEmail = true;
            })

            .AddEntityFrameworkStores<FiorrelloDbContext>();
            services.AddScoped<IHeaderService, HeaderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAppUserService, AppUserService>();

   
            
            services.AddScoped<IFileService, FileService>();
        }
    }
}
