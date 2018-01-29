using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    /// <summary>
    /// Correspomds to the wind object of OpenWeatherMap's JSON response
    /// </summary>
    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
        public override string ToString()
        {
            return string.Format("wind: {0} degrees, {1}m/s",deg.ToString(), speed.ToString());
        }
    }
    /// <summary>
    /// Correspomds to the weather object of OpenWeatherMap's JSON response
    /// </summary>
    public class WeatherDesc
    {
        public string main { get; set; }
        public string description { get; set; }
    }
    /// <summary>
    /// Correspomds to the main object of OpenWeatherMap's JSON response
    /// </summary>
    public class MainWeather
    {
        /// <summary>
        /// Temperature in kelvin
        /// </summary>
        public double temp { get; set; }
        public int humidity { get; set; }
        /// <summary>
        /// Converts klevin result to celsius
        /// </summary>
        public double Celsius { get
            {
                return temp - 273.5;
            } }
        public override string ToString()
        {
            return string .Format("Temp: {0:N3}C \nHumidity: {1}%" , Celsius, humidity.ToString());
        }
    }
    

    public class Weather
    {
        public Wind wind { get; private set; }
        public WeatherDesc weatherDesc { get; private set; }
        public MainWeather mainWeather { get; private set; }
        public Weather(Wind w, WeatherDesc wd, MainWeather mw)
        {
            wind = w;
            weatherDesc = wd;
            mainWeather = mw;
        }

        public override string ToString()
        {
            return weatherDesc.description +"\n"+ mainWeather.ToString() + "\n" + wind.ToString() + "\n";
        }
    }
}
