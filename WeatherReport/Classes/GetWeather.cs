using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherReport.Models;

namespace WeatherReport.Classes
{
    public class GetWeather
    {
        public static string Url = "https://api.openweathermap.org/data/2.5/forecast";
        public static string Key = "84747beaeb5de4cd9df7b9b814e52c4d";
        public static async Task<DataResponse> Get(float lat, float lon)
        {
            DataResponse DataResponse = null;

            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{Url}?lat={lat}&lon={lon}&units=metric&lang=ru&appid={Key}"))
                {
                    using (var response = await client.SendAsync(request))
                    {
                        string ContentResponse = await response.Content.ReadAsStringAsync();

                        DataResponse = JsonConvert.DeserializeObject<DataResponse>(ContentResponse);
                    }
                };
            };

            return DataResponse;
        }
    }
}
