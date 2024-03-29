using NetCoreBoilerplate.Domain.Entities;
using System;

namespace NetCoreBoilerplate.Api.ViewModels
{
    public class WeatherForecastViewModel
    {
        public Guid Guid { get; set; }

        public DateTime Date { get; set; }

        public double TemperatureC { get; set; }

        public double TemperatureF { get; set; }

        public string Summary { get; set; }

        public static WeatherForecastViewModel FromDomainEntity(WeatherForecast domainForecast) 
            => new WeatherForecastViewModel()
            {
                Guid = domainForecast.Guid,
                Date = domainForecast.Date,
                Summary = domainForecast.Summary,
                TemperatureC = (double)domainForecast.Temperature.Celsius,
                TemperatureF = (double)domainForecast.Temperature.Fahrenheit
            };
    }
}
