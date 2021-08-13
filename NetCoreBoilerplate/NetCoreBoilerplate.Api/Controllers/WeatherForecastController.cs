using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreBoilerplate.Api.Presenters;
using NetCoreBoilerplate.Application.Common.Pagination;
using NetCoreBoilerplate.Application.UseCases.CreateWeatherForecast;
using NetCoreBoilerplate.Application.UseCases.ListWeatherForecasts;
using System;
using System.Threading.Tasks;

namespace NetCoreBoilerplate.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    { 
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ListWeatherForecastsInteractor _listWeatherForecastsInteractor;
        private readonly CreateWeatherForecastInteractor _createWeatherForecastInteractor;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            ListWeatherForecastsInteractor listWeatherForecastsInteractor,
            CreateWeatherForecastInteractor createWeatherForecastInteractor)
        {
            _logger = logger;
            _listWeatherForecastsInteractor = listWeatherForecastsInteractor;
            _createWeatherForecastInteractor = createWeatherForecastInteractor;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int perPage = 20)
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateWeatherForecastRequest request)
        {
            //var request = new CreateWeatherForecastRequest()
            //{
            //    Date = date,
            //    Summary = summary,
            //    Temperature = temperature,
            //    TemperatureUnit = temperatureUnit
            //};

            var presenter = new CreateWeatherForecastHttpPresenter();

            await _createWeatherForecastInteractor
                .SetRequest(request)
                .SetPresenter(presenter)
                .Invoke();

            return presenter.Result;
        }
    }
}
