using Microsoft.AspNetCore.Mvc;
using NetCoreBoilerplate.Api.ViewModels;
using NetCoreBoilerplate.Application.UseCases.ListWeatherForecasts;

namespace NetCoreBoilerplate.Api.Presenters
{
    public class ListWeatherForecastsHttpPresenter : BaseHttpPresenter<ListWeatherForecastsResponse>, IListWeatherForecastsPresenter
    {
        public override void PresentSuccess(ListWeatherForecastsResponse response)
        {
            Result = new OkObjectResult(response.PaginatedForecasts.Select(WeatherForecastViewModel.FromDomainEntity));
        }
    }
}
