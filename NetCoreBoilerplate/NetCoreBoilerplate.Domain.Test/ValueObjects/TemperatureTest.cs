using FluentAssertions;
using NetCoreBoilerplate.Domain.Exceptions.Temperature;
using NetCoreBoilerplate.Domain.ValueObjects;
using System;
using Xunit;

namespace NetCoreBoilerplate.Domain.Test.ValueObjects
{
    public class TemperatureTest
    {
        [Fact]
        public void When_CelsiusIs26Point8_Expect_FahrenheitToBe78Point8()
        {
            var celsius = 26.8m;
            var temperature = Temperature.FromCelsius(celsius);

            var fahrenheit = temperature.Fahrenheit;

            fahrenheit.Should().Be(80.24m);
        }

        [Fact]
        public void When_FahrenheitIs87Point9_Expect_CelsiusToBe559over18()
        {
            var fahrenheit = 87.9m;
            var temperature = Temperature.FromFahrenheit(fahrenheit);

            var celsius = temperature.Celsius;

            celsius.Should().Be(decimal.Divide(559m, 18m));
        }

        [Fact]
        public void Given_CelsiusIs17Point3_When_Adding2Point6Celsius_Expect_CelsiusToBe19Point9()
        {
            var originalCelsius = 17.3m;
            var celsiusToAdd = 2.6m;
            var temperature = Temperature.FromCelsius(originalCelsius);

            temperature = temperature.AddCelsius(celsiusToAdd);
            var newCelsius = temperature.Celsius;

            newCelsius.Should().Be(19.9m);
        }

        [Fact]
        public void When_CelsiusIsLowerThanMinus273Point15_Expect_TemperatureUnderAbsoluteZeroException()
        {
            Action createTemperatureUnderAbsoluteZeroAction = () => Temperature.FromCelsius(-274m);

            createTemperatureUnderAbsoluteZeroAction.Should().Throw<TemperatureUnderAbsoluteZeroException>();
        }
    }
}
