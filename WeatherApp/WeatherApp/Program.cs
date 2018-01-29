using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    class Program
    {
        private const string _APIKEY = "b21da8b713fbce72cdc1d0d012875d12";
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Enter location and press enter");
                string input = Console.ReadLine();
                try
                {
                    DataGrabber dataGrabber = new DataGrabber(input, _APIKEY);
                    var t = dataGrabber.getWeather();
                    Console.WriteLine("Weather for {0}:", input);
                    Console.WriteLine(t.ToString());
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("The API request failed! Are you sure thats a valid location?");
                }
            }
        }
    }
}
