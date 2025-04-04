
using BankApp.API.Middleware;
using BankApp.Identity;
using BankingApp.Application;
using BankingApp.Application.LoginModels;
using BankingApp.Infrastructure;

namespace BankingApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddInterfaceServices(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);
            builder.Services.AddApplicationServices();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseMiddleware<ExceptionMiddleware>();


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
