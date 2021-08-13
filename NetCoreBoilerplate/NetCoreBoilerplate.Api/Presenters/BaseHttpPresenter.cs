using Microsoft.AspNetCore.Mvc;
using NetCoreBoilerplate.Application.Common;

namespace NetCoreBoilerplate.Api.Presenters
{
    public abstract class BaseHttpPresenter<T> : IUseCasePresenter<T> where T : IUseCaseResponse
    {
        public IActionResult Result { get; protected set; }

        public abstract void PresentSuccess(T response);

        public void PresentUnknownError() => Result = new StatusCodeResult(500);
    }
}
