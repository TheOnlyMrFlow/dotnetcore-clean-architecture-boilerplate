﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBoilerplate.Application.Common
{
    public interface IUseCasePresenter<IUseCaseResponse>
    {
        void PresentSuccess(IUseCaseResponse response);

        void PresentUnknownError();
    }
}
