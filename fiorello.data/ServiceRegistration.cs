using fiorello.data.Abstract;
using fiorello.data.Concrete;
using fiorello.data.Context;
using fiorello.entity.Entities.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.data
{
    public static class ServiceRegistration
    {
        public static void AddDataRegistration(this IServiceCollection services )
        {
            services.AddDbContext<FiorrelloDbContext>(options =>
            {
                options.UseSqlServer(Configuration.ConnectionString);
            });

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.User.RequireUniqueEmail = true;
            })

            .AddEntityFrameworkStores<FiorrelloDbContext>();
            
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IHeaderReadRepository, HeaderReadRepository>();
            services.AddScoped<IHeaderWriteRepository, HeaderWriteRepository>();
            services.AddScoped<IFilesReadRepository, FilesReadRepository>();
            services.AddScoped<IFilesWriteRepository, FilesWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

           

        }

       


    }
}
