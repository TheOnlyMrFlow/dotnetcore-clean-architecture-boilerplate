using NetCoreBoilerplate.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBoilerplate.Domain.Entities
{
    public class WeatherForecast
    {
        public Guid Guid { get; set; }

        public DateTime Date { get; set; }

        public Temperature Temperature { get; set; }

        public string Summary { get; set; }
    }
}
