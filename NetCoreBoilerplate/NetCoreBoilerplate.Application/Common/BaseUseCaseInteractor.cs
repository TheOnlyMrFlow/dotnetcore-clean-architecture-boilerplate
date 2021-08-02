using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBoilerplate.Application.Common
{
    public abstract class BaseUseCaseInteractor<TRequest, TResponse> where TResponse : IUseCaseResponse
    {
        protected IUseCasePresenter<TResponse> _presenter;

        protected TRequest _request;

        public BaseUseCaseInteractor<TRequest, TResponse> SetPresenter(IUseCasePresenter<TResponse> presenter)
        {
            _presenter = presenter;

            return this;
        }

        public BaseUseCaseInteractor<TRequest, TResponse> SetRequest(TRequest request)
        {
            _request = request;

            return this;
        }

        public abstract Task Invoke();
    }
}
