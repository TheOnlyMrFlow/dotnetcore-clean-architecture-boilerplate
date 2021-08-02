using NetCoreBoilerplate.Application.Common.Pagination;

namespace NetCoreBoilerplate.Application.UseCases.ListWeatherForecasts
{
    public class ListWeatherForecastsRequest
    {
        public PaginationSpec PaginationSpec { get; set; }
    }
}
