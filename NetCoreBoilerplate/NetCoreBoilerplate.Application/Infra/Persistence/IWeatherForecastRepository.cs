using NetCoreBoilerplate.Application.Common.Pagination;
using NetCoreBoilerplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBoilerplate.Application.Infra.Persistence
{
    public interface IWeatherForecastRepository
    {
        public Task<IEnumerable<WeatherForecast>> ListForecasts();

        public Task<PaginatedResult<WeatherForecast>> ListForecasts(PaginationSpec paginationSpec);
    }
}
