using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReport.Classes
{
    public class GetWeather
    {
        public static string Url = "https://api.weather.yandex.ru/v2/forecast";
        public static string Key = "demo_yandex_weather_api_key_ca6d09349ba0";
        public static async Task Get(float lat, float lon)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{Url}?lat={lat}&lon={lon}".Replace(",", ".")))
                {
                    request.Headers.Add("X-Yandex-Weather-Key", Key);

                    using (var response = await client.SendAsync(request))
                    {
                        string DataResponse = await response.Content.ReadAsStringAsync();
                    }
                };
            };

        }
    }
}
