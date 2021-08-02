using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreBoilerplate.Api.Presenters;
using NetCoreBoilerplate.Application.Common.Pagination;
using NetCoreBoilerplate.Application.UseCases.ListWeatherForecasts;
using System.Threading.Tasks;

namespace NetCoreBoilerplate.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    { 
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ListWeatherForecastsInteractor _listWeatherForecastsInteractor;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            ListWeatherForecastsInteractor listWeatherForecastsInteractor)
        {
            _logger = logger;
            _listWeatherForecastsInteractor = listWeatherForecastsInteractor;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page, int perPage)
        {
            var request = new ListWeatherForecastsRequest()
            {
                PaginationSpec = new PaginationSpec(page, perPage)
            };

            var presenter = new ListWeatherForecastsHttpPresenter();

            await _listWeatherForecastsInteractor
                .SetRequest(request)
                .SetPresenter(presenter)
                .Invoke();

            return presenter.Result;
        }
    }
}
