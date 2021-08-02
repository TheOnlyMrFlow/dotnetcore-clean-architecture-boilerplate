using Microsoft.EntityFrameworkCore;
using NetCoreBoilerplate.Application.Common.Pagination;
using NetCoreBoilerplate.Application.Infra.Persistence;
using NetCoreBoilerplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreBoilerplate.Persistence.EFCore.Repositories
{
    public class WeatherForecastEFRepository : IWeatherForecastRepository
    {
        private BoilerplateDbContext _dbContext { get; }

        public WeatherForecastEFRepository(BoilerplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<WeatherForecast>> ListForecasts()
        {
            return await _dbContext.WeatherForecasts
                .Select(dbForecast => dbForecast.ToDomainEntity())
                .ToListAsync();
        }

        public async Task<PaginatedResult<WeatherForecast>> ListForecasts(PaginationSpec paginationSpec)
        {
            return new PaginatedResult<WeatherForecast>()
            {
                Page = paginationSpec.Page,
                PerPage = paginationSpec.PerPage,
                TotalPages = (int)Math.Ceiling((double)await GetWeatherForecastsCount() / paginationSpec.PerPage),
                Result = _dbContext.WeatherForecasts
                .Skip((paginationSpec.Page - 1) * paginationSpec.PerPage)
                .Take(paginationSpec.PerPage)
                .Select(dbForecast => dbForecast.ToDomainEntity())
            };
        }

        private Task<int> GetWeatherForecastsCount()
        {
            return _dbContext.WeatherForecasts.CountAsync();
        }
    }
}
