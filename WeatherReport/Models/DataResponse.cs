using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReport.Models
{
    public class DataResponse
    {
        public List<ForecastItem> list { get; set; }
    }

    public class ForecastItem
    {
        public long dt { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

    public class Weather
    {
        public string description { get; set; }
    }

    public class Hour
    {
        public DateTime time { get; set; }
        public double temp { get; set; }
        public double feels_like { get; set; }
        public int humidity { get; set; }
        public int pressure { get; set; }
        public string description { get; set; }
    }
}
