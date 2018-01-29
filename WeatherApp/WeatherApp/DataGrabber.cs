/* 
 * This class uses API from open weathermap to get current weather.
 * 
 */

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WeatherApp
{
    /// <summary>
    /// Wrapper class for API client
    /// </summary>
    class DataGrabber
    {
        /// <summary>
        /// The API key used in API requests
        /// </summary>
        private string _ApiKey;
        /// <summary>
        /// City to get weather for
        /// </summary>
        private string _City;
        private Uri _ApiRequest { get
            {
                return new Uri(string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}", _City, _ApiKey));
            } }
        /// <summary>
        /// Creates a new DataGrabber object containing the 
        /// </summary>
        /// <param name="DataSource">The API command to execute</param>
        /// <exception cref="ArgumentNullException">Gets thrown if a parameter is null</exception>
        public DataGrabber(string City, string ApiKey)
        {
            if (!string.IsNullOrWhiteSpace(City))
                _City = City;
            else
                throw new ArgumentNullException("City");
            if (!string.IsNullOrWhiteSpace(ApiKey))
                _ApiKey = ApiKey;
            else
                throw new ArgumentNullException("ApiKey");
        }
        /// <summary>
        /// Gets data from the API using the provided API information.
        /// </summary>
        private async Task<JObject> GetJsonData()
        {
            using(HttpClient client = new HttpClient())
            {
                JObject jObject = new JObject();
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
                var response = await client.GetAsync(_ApiRequest);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    jObject = JObject.Parse(result);
                }
                return jObject;
            }
        }
        /// <summary>
        /// Converts the weather information to their corresponding objects.
        /// </summary>
        /// <param name="JsonWeather">JObject with the required weather objects</param>
        /// <exception cref="ArgumentNullException">Gets thrown when the json object is null or empty Either the location is invalid or the API request failed</exception>
        /// <returns>returns the weather object parsed</returns>
        private Weather ParseJObjectToWeather(JObject JsonWeather)
        {
            if (!(JsonWeather == null || JsonWeather.Count == 0))
            {
                Wind wind = JsonWeather["wind"].ToObject<Wind>();
                MainWeather w = JsonWeather["main"].ToObject<MainWeather>();
                WeatherDesc wd = JsonWeather["weather"][0].ToObject<WeatherDesc>();
                return new Weather(wind, wd, w);
            }
            else
            {
                throw new ArgumentNullException("JsonWeather");
            }
        }

        /// <summary>
        /// gets the current weather 
        /// </summary>
        /// <returns>Weather object containing the weather information</returns>
        public Weather getWeather()
        {
            JObject j = GetJsonData().Result;
            return ParseJObjectToWeather(j);
        }
    }
}
