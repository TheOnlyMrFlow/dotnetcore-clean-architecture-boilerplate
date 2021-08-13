using NetCoreBoilerplate.Application.Common;
using NetCoreBoilerplate.Application.Infra.Persistence;
using NetCoreBoilerplate.Domain.Entities;
using NetCoreBoilerplate.Domain.Exceptions.Temperature;
using NetCoreBoilerplate.Domain.Validators;
using NetCoreBoilerplate.Domain.ValueObjects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreBoilerplate.Application.UseCases.CreateWeatherForecast
{
    public class CreateWeatherForecastInteractor : BaseUseCaseInteractor<CreateWeatherForecastRequest, CreateWeatherForecastResponse, ICreateWeatherForecastPresenter>
    {
        private IWeatherForecastRepository _weatherForecastRepository { get; }

        public CreateWeatherForecastInteractor(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public override async Task Invoke()
        {
            try
            {
                var temperature = 
                    _request.TemperatureUnit == CreateWeatherForecastRequest.ETemperatureUnit.Celsius
                    ? Temperature.FromCelsius((decimal)_request.Temperature)
                    : Temperature.FromFahrenheit((decimal)_request.Temperature);

                var weatherForecast = new WeatherForecast()
                {
                    Guid = Guid.NewGuid(),
                    Date = _request.Date,
                    Summary = _request.Summary,
                    Temperature = temperature
                };

                var validator = new IsWeatherForecastValid();
                var validationResult = validator.Validate(weatherForecast);

                if (! validationResult.IsValid)
                {
                    _presenter?.PresentInvalidEntityError(validationResult.Errors.Select(err => err.Message));

                    return;
                }

                await _weatherForecastRepository.CreateForecast(weatherForecast);

                _presenter?.PresentSuccess(new CreateWeatherForecastResponse() { NewWeatherForecastGuid = weatherForecast.Guid });
            }
            catch (TemperatureUnderAbsoluteZeroException e)
            {
                _presenter?.PresentInvalidEntityError(new[] { "Temperature is under absolute zero." });
            }
            catch (Exception e)
            {
                _presenter?.PresentUnknownError();
            }
        }
    }
}
