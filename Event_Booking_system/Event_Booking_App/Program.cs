using System.Threading.Tasks;
using Event_Booking_App.Context;
using Event_Booking_App.Models;
using Event_Booking_App.Repository;
using Event_Booking_App.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Event_Booking_App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();

            //Connection with database
            string conn = builder.Configuration.GetConnectionString("LocaldatabaseConnection");
            builder.Services.AddDbContext<EventBookingDB>(options => options.UseSqlServer(conn));

            builder.Services.AddScoped<IEventService, EventService>();
            builder.Services.AddScoped<IEventRepository, EventRepository>();

            builder.Services.AddScoped<ITicketBookingServices, TicketBookingService>();
            builder.Services.AddScoped<ITicketBookingRepository, TicketBookingRepository>();

            builder.Services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<EventBookingDB>();
                     

            var app = builder.Build();
            //builder.Services.Configure<>

            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                await SeedRolesAndAdmin(service);
            }
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();




        }
        static async Task SeedRolesAndAdmin(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            string[] roleNames = { "User", "Admin", "Organizer" };

            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            string adminEmail = "admin@example.com";
            string adminPassword = "Admin@123";

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User",
                    EmailConfirmed = true
                };

                var createUserResult = await userManager.CreateAsync(adminUser, adminPassword);
                if (createUserResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            string organizerEmail = "organizer@gmail.com";
            string organizerPassword = "Organizer@]123";

            if (await userManager.FindByEmailAsync(organizerEmail) == null)
            {
                var organizerUser = new User
                {
                    UserName = organizerEmail,
                    Email = organizerEmail,
                    FirstName = "Event",
                    LastName = "Organizer",
                    EmailConfirmed = true
                };
                var createOrganizerResult = await userManager.CreateAsync(organizerUser, organizerPassword);
                if (createOrganizerResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(organizerUser, "Organizer");
                }

            }
        }
    }
}