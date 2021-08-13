using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBoilerplate.Application.Common
{
    public abstract class BaseUseCaseInteractor<TRequest, TResponse, TPresenter>
        where TResponse : IUseCaseResponse
        where TPresenter : IUseCasePresenter<TResponse>
    {
        protected TPresenter _presenter;

        protected TRequest _request;

        public BaseUseCaseInteractor<TRequest, TResponse, TPresenter> SetPresenter(TPresenter presenter)
        {
            _presenter = presenter;

            return this;
        }

        public BaseUseCaseInteractor<TRequest, TResponse, TPresenter> SetRequest(TRequest request)
        {
            _request = request;

            return this;
        }

        public abstract Task Invoke();
    }
}
