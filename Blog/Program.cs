using Blog.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog {
	public class Program {
		public static void Main(string[] args) {
			var host = CreateHostBuilder(args).Build();

			var scope = host.Services.CreateScope();

			try {
				var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
				var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
				var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

				ctx.Database.EnsureCreated();

				if (!ctx.Roles.Any()) {
					roleManager.CreateAsync(new IdentityRole("admin")).GetAwaiter().GetResult();
				}

				if (!ctx.Users.Any(u => u.UserName == "admin")) {
					var adminUser = new IdentityUser {
						UserName = "admin",
						Email = "admin@email.com"
					};

					userManager.CreateAsync(adminUser, "password").GetAwaiter().GetResult();
					userManager.AddToRoleAsync(adminUser, "admin").GetAwaiter().GetResult();
				}
			} catch (Exception ex) {

				Console.WriteLine(ex.Message);
			}

			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder => {
					webBuilder.UseStartup<Startup>();
				});
	}
}
