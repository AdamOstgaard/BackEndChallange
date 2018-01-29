/* 
 * This class uses API from open weathermap to get current weather.
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Updates the weather object
        /// </summary>
        public void Update()
        {

        }
    }
}
