using Dal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebBurger.Binders;
using WebBurger.Repository;
using WebBurger.Repository.Contracts;
using WebBurger.Services;

namespace WebBurger
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<IBurgerRepository, BurgerRepository>();
			services.AddScoped<IBeverageRepository, BeverageRepository>();
			services.AddScoped<IMenuRepository, MenuRepository>();
			services.AddScoped<IDessertRepository, DessertRepository>();
			services.AddScoped<ISideRepository, SideRepository>();

			services.AddTransient<MenuService>();

			services.AddDbContext<BurgerContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("BurgerDb"))
				);

			//services.AddControllersWithViews();
			services.AddControllersWithViews(conf =>
			{
				conf.ModelBinderProviders[4] = new FloatingTypeModelBinderProvider();
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}