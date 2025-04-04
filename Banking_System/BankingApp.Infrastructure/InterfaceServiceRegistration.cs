using BankingApp.Domain.Interface;
using BankingApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankingApp.Infrastructure
{
    public static class InterfaceServiceRegistration 
    {
        public static IServiceCollection AddInterfaceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BankingDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LocalConnectionString"));

            });

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            return services;


        }
    }
}
