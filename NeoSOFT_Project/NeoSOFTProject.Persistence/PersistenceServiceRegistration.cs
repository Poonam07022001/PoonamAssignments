using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NeoSOFTProject.Application.Contracts.Persistence;
using NeoSOFTProject.Persistence.Repositories;

namespace NeoSOFTProject.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddInterfaceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LocalConnectionString"));

            });

            services.AddScoped<IBookRepository, BookRepository>();
            //services.AddScoped<IAuthorRepository, AuthorRepository>();
            return services;


        }
    }
}
