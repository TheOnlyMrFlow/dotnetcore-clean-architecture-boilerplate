using DomainValidationCore.Validation;
using NetCoreBoilerplate.Domain.Entities;
using NetCoreBoilerplate.Domain.Validators.Specifications;
using System;

namespace NetCoreBoilerplate.Domain.Validators
{
    public class IsWeatherForecastValid : Validator<WeatherForecast>
    {
        public IsWeatherForecastValid()
        {
            Add("SummaryIsNotNullOrWhiteSpace", new Rule<WeatherForecast>(new IsNotNullish<WeatherForecast>(x => x.Summary), "Summary field is missing"));
            Add("SummaryIsLessThan200CharacterLong", new Rule<WeatherForecast>(new IsTrue<WeatherForecast>(x => x.Summary.Length <= 200), "Summary length is longer than 200 characters"));
        }
    }
}
