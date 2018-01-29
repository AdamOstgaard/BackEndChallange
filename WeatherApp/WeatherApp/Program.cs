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
        private const string _CITYLISTLOCATION = "Resources\\city.list.json";
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            CityManager c = new CityManager(_CITYLISTLOCATION);
            //TODO: Add exceptionhandling for when location is not valid and for when city list is non existing.
            DataGrabber dataGrabber = new DataGrabber(c.GetIdFromName(input), _APIKEY);
            var t = dataGrabber.getWeather();
            Console.WriteLine(t.ToString());
            Console.ReadKey();
        }
    }
}
