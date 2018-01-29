/* 
 * This class uses API from open weathermap to get current weather.
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WeatherApp
{
    class DataGrabber
    {
        private string _ApiKey;
        private string _CityId;
        private Uri _ApiRequest { get
            {
                return new Uri(string.Format("api.openweathermap.org/data/2.5/weather?id={0}&APPID={1}", _CityId, _ApiKey));
            } }
        /// <summary>
        /// Creates a new DataGrabber object containing the 
        /// </summary>
        /// <param name="DataSource">The API command to execute</param>
        /// <exception cref="ArgumentNullException">Gets thrown if a parameter is null</exception>
        public DataGrabber(string CityId, string ApiKey)
        {
            if (!string.IsNullOrWhiteSpace(CityId))
                _CityId = CityId;
            else
                throw new ArgumentNullException("CityId");
            if (!string.IsNullOrWhiteSpace(ApiKey))
                _ApiKey = ApiKey;
            else
                throw new ArgumentNullException("ApiKey");
        }
        /// <summary>
        /// Gets data from the API using the provided API information.
        /// </summary>
        private async Task<JArray> GetJsonData()
        {
            using(HttpClient client = new HttpClient())
            {
                JArray arr = new JArray();
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
                var response = await client.GetAsync(_ApiRequest);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    arr = JArray.Parse(result);
                }
                return arr;
            }
        }
    }
}
