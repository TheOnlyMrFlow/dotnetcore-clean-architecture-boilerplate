using Microsoft.AspNetCore.Mvc;
using NetCoreBoilerplate.Application.UseCases.CreateWeatherForecast;
using System.Collections.Generic;

namespace NetCoreBoilerplate.Api.Presenters
{
    public class CreateWeatherForecastHttpPresenter : BaseHttpPresenter<CreateWeatherForecastResponse>, ICreateWeatherForecastPresenter
    {
        public void PresentInvalidEntityError(IEnumerable<string> validationErrors)
            => Result = new BadRequestObjectResult(validationErrors);

        public override void PresentSuccess(CreateWeatherForecastResponse response)
            => Result = new ObjectResult(response.NewWeatherForecastGuid.ToString()) { StatusCode = 201 };
    }
}
