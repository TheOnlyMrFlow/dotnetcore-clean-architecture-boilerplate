using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NetCoreBoilerplate.Application.Infra.Persistence;
using NetCoreBoilerplate.Application.UseCases.CreateWeatherForecast;
using NetCoreBoilerplate.Application.UseCases.ListWeatherForecasts;
using NetCoreBoilerplate.Persistence.EFCore;
using NetCoreBoilerplate.Persistence.EFCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreBoilerplate.Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NetCoreBoilerplate.Api", Version = "v1" });
            });

            services.AddDbContext<BoilerplateDbContext>(
                options => options.UseSqlite(@$"Data source=C:\Users\comte\Documents\NetCoreBoilerplate\db.sqlite"));

            // interactors
            services.AddTransient<ListWeatherForecastsInteractor>();
            services.AddTransient<CreateWeatherForecastInteractor>();

            // repositories
            services.AddTransient<IWeatherForecastRepository, WeatherForecastEFRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetCoreBoilerplate.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
