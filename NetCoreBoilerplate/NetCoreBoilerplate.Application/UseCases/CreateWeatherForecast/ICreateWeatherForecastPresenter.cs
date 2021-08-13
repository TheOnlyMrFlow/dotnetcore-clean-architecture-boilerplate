using NetCoreBoilerplate.Application.Common;
using System.Collections.Generic;

namespace NetCoreBoilerplate.Application.UseCases.CreateWeatherForecast
{
    public interface ICreateWeatherForecastPresenter : IUseCasePresenter<CreateWeatherForecastResponse>
    {
        void PresentInvalidEntityError(IEnumerable<string> validationErrors);
    }
}
