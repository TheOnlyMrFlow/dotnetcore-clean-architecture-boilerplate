using Microsoft.EntityFrameworkCore;
using NetCoreBoilerplate.Domain.Entities;
using NetCoreBoilerplate.Domain.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreBoilerplate.Persistence.EFCore.DatabaseEntities
{
    [Table("WeatherForecast")]
    internal class DbWeatherForecast
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public Guid Guid { get; set; }

        public decimal Celsius { get; set; }

        public string Summary { get; set; }

        public WeatherForecast ToDomainEntity()
        {
            return new WeatherForecast()
            {
                Date = Date,
                Guid = Guid,
                Summary = Summary,
                Temperature = Temperature.FromCelsius(Celsius)
            };
        }

        public DbWeatherForecast FromDomainEntity(WeatherForecast weatherForecast)
        {
            return new DbWeatherForecast()
            {
                Date = weatherForecast.Date,
                Guid = weatherForecast.Guid,
                Summary = weatherForecast.Summary,
                Celsius = weatherForecast.Temperature.Celsius
            };
        }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbWeatherForecast>()
                .HasIndex(x => x.Guid);

            modelBuilder.Entity<DbWeatherForecast>()
                .HasIndex(x => x.Date);
        }
    }
}
