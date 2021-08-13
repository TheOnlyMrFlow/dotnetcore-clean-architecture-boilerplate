using System;

namespace NetCoreBoilerplate.Application.UseCases.CreateWeatherForecast
{
    public class CreateWeatherForecastRequest
    {
        public enum ETemperatureUnit
        {
            Celsius,
            Fahrenheit
        }

        public DateTime Date { get; set; }

        public string Summary { get; set; }

        public double Temperature { get; set; }

        public ETemperatureUnit TemperatureUnit { get; set; }
    }
}
