
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
        var useSqlite = builder.Configuration.GetConnectionString("UseSqlite"); 
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();
         var dbhost=Environment.GetEnvironmentVariable("DB_HOST") ?? "DESKTOP\\SQLEXPRESS";
        var dbname = Environment.GetEnvironmentVariable("DBNAME") ?? "travelto";
        var pwd = Environment.GetEnvironmentVariable("DB_SA_PASS") ?? "nagazi2@";
        builder.Configuration["ConnectionStrings:DefaultConnection"] = $"Data Source={dbhost};Initial Catalog={dbname};User Id=sa;Password={pwd};TrustServerCertificate=True";
        builder.Services.AddDbContext<ApplicationDataContext>(options =>
        {
            if (useSqlite=="true")
            {
                options.UseSqlite("Data Source=app.db");
            }
            else
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        });
		builder.Services.AddDistributedMemoryCache();
		builder.Services.AddSession(options =>
		{
			options.IdleTimeout = TimeSpan.FromSeconds(10);
			options.Cookie.HttpOnly = true;
			options.Cookie.IsEssential = true;
		});
		//builder.Services.AddDbContext<UsersDbContext>(options => options.UseSqlServer(
		//    builder.Configuration.GetConnectionString("UserCon")
		//    ));
        
		builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDataContext>();
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
		app.UseSession();

		app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDataContext>();
            db.Database.Migrate(); 
        }
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
            var UserManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            string email = "admin@admin.com";
            string password = "Admin1111.";
            if (await UserManager.FindByEmailAsync(email) == null)
            {
                var user = new User();
                user.UserName = email;
                user.Email = email;
                await UserManager.CreateAsync(user, password);
                await UserManager.AddToRoleAsync(user, "Admin");
            }
        }
        app.Run();
    }
}