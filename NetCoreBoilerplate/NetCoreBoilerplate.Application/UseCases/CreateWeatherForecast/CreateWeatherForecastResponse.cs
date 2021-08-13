using NetCoreBoilerplate.Application.Common;
using System;

namespace NetCoreBoilerplate.Application.UseCases.CreateWeatherForecast
{
    public class CreateWeatherForecastResponse : IUseCaseResponse
    {
        public Guid NewWeatherForecastGuid { get; set; }
    }
}
