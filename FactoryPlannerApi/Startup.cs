namespace FactoryPlannerApi
{
	using FactoryPlannerApi.Models;

	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;

	using Newtonsoft.Json.Serialization;

	public class Startup
	{
		/// <summary>
		/// The name of the default connection name in the app settings
		/// </summary>
		private const string _defaultConnectionName = "DevConnection";

		public Startup ( IConfiguration configuration )
		{
			this.Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices ( IServiceCollection services )
		{
			services.AddMvc().SetCompatibilityVersion( CompatibilityVersion.Version_2_1 ).AddJsonOptions(
			                                                                                             options =>
				                                                                                             {
					                                                                                             var resolver = options.SerializerSettings.ContractResolver;
					                                                                                             if ( resolver != null )
					                                                                                             {
						                                                                                             ( (DefaultContractResolver)resolver ).NamingStrategy = null;
					                                                                                             }
				                                                                                             } );

			services.AddDbContext<FactoryPlannerContext>( options => options.UseSqlServer( this.Configuration.GetConnectionString( _defaultConnectionName ) ) );
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure ( IApplicationBuilder app, IHostingEnvironment env )
		{
			if ( env.IsDevelopment() )
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();
		}
	}
}