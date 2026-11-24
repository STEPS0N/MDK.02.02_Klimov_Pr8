using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReport.Models
{
    public class YandexGeoResponse
    {
        public YandexResponse response { get; set; }
    }

    public class YandexResponse
    {
        public YandexGeoObjectCollection GeoObjectCollection { get; set; }
    }

    public class YandexGeoObjectCollection
    {
        public List<YandexFeatureMember> featureMember { get; set; }
    }

    public class YandexFeatureMember
    {
        public YandexGeoObject GeoObject { get; set; }
    }

    public class YandexGeoObject
    {
        public YandexPoint Point { get; set; }
    }

    public class YandexPoint
    {
        public string pos { get; set; }
    }
}
