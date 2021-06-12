using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using OceanDataAPI.Data;
using OceanDataAPI.Repositories;
using OceanDataAPI.Services;
using System;
using System.Linq;

namespace OceanDataAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }


		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<OceanDataContext>(options =>
				options.UseSqlite("filename = OceanDatabase.db"));

			services.AddAutoMapper(typeof(Startup));

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "OceanDataAPI", Version = "v1" });
			});


			services.AddScoped<IDataPointRepo, DataPointRepo>();
			services.AddScoped<ILocationRepo, LocationRepo>();

			services.AddTransient<IDataPointService, DataPointService>();
		}


		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OceanDataAPI v1"));


				// Seed Database
				using var scope = app.ApplicationServices.CreateScope();
				var scopedServices = scope.ServiceProvider;
				var db = scopedServices.GetRequiredService<OceanDataContext>();
				var logger = scopedServices
					.GetRequiredService<ILogger<Startup>>();

				db.Database.EnsureCreated();

				try
				{
					if (!db.DataPoints.Any())
					{
						SeedData.Initialize(db);
					}
				}
				catch (Exception ex)
				{
					logger.LogError(ex, "An error occurred seeding the " +
						"database with test messages. Error: {Message}", ex.Message);
				}

			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
