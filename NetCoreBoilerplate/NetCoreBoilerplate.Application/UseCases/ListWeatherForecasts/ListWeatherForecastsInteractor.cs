using NetCoreBoilerplate.Application.Common;
using NetCoreBoilerplate.Application.Infra.Persistence;
using System;
using System.Threading.Tasks;

namespace NetCoreBoilerplate.Application.UseCases.ListWeatherForecasts
{
    public class ListWeatherForecastsInteractor : BaseUseCaseInteractor<ListWeatherForecastsRequest, ListWeatherForecastsResponse>
    {
        private IWeatherForecastRepository _forecastRepository { get; }

        public ListWeatherForecastsInteractor(IWeatherForecastRepository forecastRepository)
        {
            _forecastRepository = forecastRepository;
        }

        public override async Task Invoke()
        {
            try
            {
                var response = new ListWeatherForecastsResponse();
                response.PaginatedForecasts = await _forecastRepository.ListForecasts(_request.PaginationSpec);
                _presenter?.PresentSuccess(response);

                return;
            } catch (Exception e)
            {
                _presenter?.PresentUnknownError();

                return;
            }

        }
    }
}
