using NetCoreBoilerplate.Application.Common;
using NetCoreBoilerplate.Application.Infra.Persistence;
using System;
using System.Threading.Tasks;

namespace NetCoreBoilerplate.Application.UseCases.ListWeatherForecasts
{
    public class ListWeatherForecastsInteractor : BaseUseCaseInteractor<ListWeatherForecastsRequest, ListWeatherForecastsResponse, IListWeatherForecastsPresenter>
    {
        private IWeatherForecastRepository _weatherForecastRepository { get; }

        public ListWeatherForecastsInteractor(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public override async Task Invoke()
        {
            try
            {
                var response = new ListWeatherForecastsResponse();
                response.PaginatedForecasts = await _weatherForecastRepository.ListForecasts(_request.PaginationSpec);
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
