using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherReport.Models;

namespace WeatherReport.Classes
{
    public class GetCoord
    {
        public static string Key = "64e8e208-941f-4ba5-be0c-8ec05a49d1b9";

        public static async Task<(float lat, float lon)> GetCoordinates(string city)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://geocode-maps.yandex.ru/v1/?apikey={Key}&geocode={city}&format=json";

                string content = await client.GetStringAsync(url);
                var geo = JsonConvert.DeserializeObject<YandexGeoResponse>(content);

                string pos = geo?.response?.GeoObjectCollection?.featureMember?.FirstOrDefault()?.GeoObject?.Point?.pos;

                if (string.IsNullOrEmpty(pos))
                {
                    return (0, 0);
                }

                var parts = pos.Split(' ');
                float lon = float.Parse(parts[0], CultureInfo.InvariantCulture);
                float lat = float.Parse(parts[1], CultureInfo.InvariantCulture);

                return (lat, lon);
            }
        }
    }
}
