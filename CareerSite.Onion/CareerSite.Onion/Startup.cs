using CareerSite.Onion.DomainServices.Application;
using CareerSite.Onion.DomainServices.Core.Application;
using CareerSite.Onion.Infrastructure.Core.ApiClients;
using CareerSite.Onion.Infrastructure.Core.Repositories;
using CareerSite.Onion.Infrastructure.Http.BackgroundCheckApi;
using CareerSite.Onion.Infrastructure.Sql.Context;
using CareerSite.Onion.Infrastructure.Sql.Repositories;
using CareerSite.Onion.InfrastructureServices.Application;
using CareerSite.Onion.InfrastructureServices.Core.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CareerSite.Onion
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddDbContext<CareerSiteContext>();

			services.AddScoped<IApplyForPositionService, ApplyForPositionService>();
			services.AddScoped<IApplyForPositionInfrastructureService, ApplyForPositionInfrastructureService>();
			services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
			services.AddScoped<IBackgroundCheckApiClient, BackgroundCheckApiClient>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

		}
	}
}
