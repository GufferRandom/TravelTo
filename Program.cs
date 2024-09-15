
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
