using NetCoreBoilerplate.Application.Common;
using NetCoreBoilerplate.Application.Common.Pagination;
using NetCoreBoilerplate.Domain.Entities;

namespace NetCoreBoilerplate.Application.UseCases.ListWeatherForecasts
{
    public class ListWeatherForecastsResponse: IUseCaseResponse
    {
        public PaginatedResult<WeatherForecast> PaginatedForecasts { get; set; }
    }
}
