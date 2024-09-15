using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using TravelTo.Data;
using TravelTo.Models;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        //builder.Services.AddAuthentication().AddGoogle(googleOptions => 
        //{
        //    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
        //    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];

        //});
        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<ApplicationDataContext>(options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")
            ));
    
     
        builder.Services.AddRazorPages();
        var app = builder.Build();

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
        app.MapRazorPages();
        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roles = new[] { "Admin", "Manager", "User" };
            foreach (var role in roles) 
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
        using (var scope = app.Services.CreateScope())
        {
            var UserManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string email = "admin@admin.com";
            string password = "Admin1111.";
            if (await UserManager.FindByEmailAsync(email) == null)
                {
                var user = new IdentityUser();
                user.UserName = email;
                user.Email = email;
                await  UserManager.CreateAsync(user, password);
                await UserManager.AddToRoleAsync(user, "Admin");
                }


        }

        app.Run();
    }
}