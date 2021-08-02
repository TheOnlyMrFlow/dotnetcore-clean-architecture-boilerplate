using NetCoreBoilerplate.Domain.Exceptions.Temperature;
using System;

namespace NetCoreBoilerplate.Domain.ValueObjects
{
    [Serializable]
    public struct Temperature : IValueObject<Temperature>
    {
        private const decimal ABSOLUTE_ZERO_IN_CELSIUS = -273.15m;
        private Temperature(decimal celsius)
        {
            if (celsius < ABSOLUTE_ZERO_IN_CELSIUS)
                throw new TemperatureUnderAbsoluteZeroException();

            Celsius = celsius;
        }

        public decimal Celsius { get; }

        public decimal Fahrenheit => CelsiusToFahrenheit(Celsius);

        public Temperature AddCelsius(decimal celsius)
            => FromCelsius(decimal.Add(Celsius, celsius));

        public Temperature AddFahrenheit(decimal fahrenheit)
            => FromFahrenheit(decimal.Add(Fahrenheit, fahrenheit));

        public static Temperature FromCelsius(decimal celsius)
            => new Temperature(celsius);

        public static Temperature FromFahrenheit(decimal fahrenheit)
            => new Temperature(FahrenheitToCelsius(fahrenheit));

        private static decimal CelsiusToFahrenheit(decimal celsius)
            => decimal.Add(decimal.Multiply(celsius, 9m/5m), 32);

        private static decimal FahrenheitToCelsius(decimal fahrenheit)
            => decimal.Divide(decimal.Subtract(fahrenheit, 32), 9m/5m);

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (obj is not Temperature)
            {
                throw new ArgumentException($"Arg must be a {nameof(Temperature)}");
            }

            return CompareTo((Temperature) obj);
        }

        public int CompareTo(Temperature other) 
            => decimal.Compare(Celsius, other.Celsius);

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is not Temperature)
            {
                throw new ArgumentException($"Arg must be a {nameof(Temperature)}");
            }

            return Equals((Temperature)obj);
        }
        public bool Equals(Temperature other)
            => decimal.Equals(Celsius, other.Celsius);

        public override int GetHashCode() => (int)(Celsius * 100m);

        public static Temperature operator +(Temperature t1, Temperature t2) 
            => t1.AddCelsius(t2.Celsius);

        public static Temperature operator -(Temperature t1, Temperature t2) 
            => t1.AddCelsius(-t2.Celsius);

        public static bool operator ==(Temperature t1, Temperature t2) 
            => t1.Equals(t2);

        public static bool operator !=(Temperature t1, Temperature t2) 
            => !t1.Equals(t2);

        public static bool operator <(Temperature t1, Temperature t2) 
            => t1.CompareTo(t2) < 0;

        public static bool operator <=(Temperature t1, Temperature t2)
            => t1.CompareTo(t2) <= 0;

        public static bool operator >(Temperature t1, Temperature t2)
            => t1.CompareTo(t2) > 0;

        public static bool operator >=(Temperature t1, Temperature t2)
            => t1.CompareTo(t2) >= 0;
    }
}
