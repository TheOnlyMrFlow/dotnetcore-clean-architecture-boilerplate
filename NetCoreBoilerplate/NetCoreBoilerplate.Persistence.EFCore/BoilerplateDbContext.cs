using System;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using NetCoreBoilerplate.Persistence.EFCore.DatabaseEntities;

namespace NetCoreBoilerplate.Persistence.EFCore
{

    public class BoilerplateDbContext : DbContext
    {
        public BoilerplateDbContext(DbContextOptions<BoilerplateDbContext> options) : base(options) { }

        internal DbSet<DbWeatherForecast> WeatherForecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DbWeatherForecast.OnModelCreating(modelBuilder);
        }
    }
}
