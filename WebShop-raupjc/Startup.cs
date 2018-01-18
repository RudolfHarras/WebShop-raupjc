using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebShop_raupjc.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WebShop_raupjc.Data;
using WebShop_raupjc.Services;


namespace WebShop_raupjc
{

	public class Startup
	{
		private readonly IConfigurationRoot _configuration;
		public Startup(IHostingEnvironment env)
		{
			_configuration = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json")
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
				.Build();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					_configuration["ConnectionStrings:WebshopArtikl"]));

			services.AddDbContext<AppIdentityDbContext>(options =>
				options.UseSqlServer(
					_configuration["ConnectionStrings:WebshopArtikl"]));

			services.AddIdentity<ApplicationUser, IdentityRole>(options =>
				{
					options.Password.RequireNonAlphanumeric = false;
					options.Password.RequireUppercase = false;
					options.Password.RequireDigit = false;
					options.Password.RequireLowercase = false;
				})
				.AddEntityFrameworkStores<AppIdentityDbContext>()
				.AddDefaultTokenProviders();


			services.AddAuthentication().AddFacebook(facebookOptions =>
			{
				facebookOptions.AppId = _configuration["Authentication:Facebook:AppId"];
				facebookOptions.AppSecret = _configuration["Authentication:Facebook:AppSecret"];
			});


			services.AddSingleton<IEmailSender, EmailSender>();
			services.AddTransient<IProductRepository, ProductRepository>();
			services.AddScoped(SessionCart.GetCart);
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddTransient<IOrderRepository, OrderRepository>();
			services.AddMvc();
			services.AddMemoryCache();
			services.AddSession();

			CreateRoles(services.BuildServiceProvider()).Wait();


		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env,
							  ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseStatusCodePages();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}
			app.UseStaticFiles();
			app.UseSession();
			app.UseAuthentication();

		
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Product}/{action=List}/{id?}");
			});

			DefaultData.EnsurePopulated(app);
		}

		private static async Task CreateRoles(IServiceProvider serviceProvider)
		{
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
			string[] roleNames = { "Admin" };

			foreach (var roleName in roleNames)
			{
				var roleExist = await roleManager.RoleExistsAsync(roleName);
				if (!roleExist)
				{
					await roleManager.CreateAsync(new IdentityRole(roleName));
				}
			}

			var user = await userManager.FindByEmailAsync("admin@admin.hr");
			if (user == null)
			{
				var poweruser = new ApplicationUser
				{
					UserName = "Admin",
					Email = "admin@admin.hr"
				};
				const string adminPassword = "T0p_secret_lozinka";
			
				var createPowerUser = await userManager.CreateAsync(poweruser, adminPassword);
				if (createPowerUser.Succeeded)
				{
					await userManager.AddToRoleAsync(poweruser, "Admin");
				}
			}
		}
	}
}