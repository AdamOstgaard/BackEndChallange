using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {

            DataGrabber dataGrabber = new DataGrabber("2673730", "b21da8b713fbce72cdc1d0d012875d12");
            var t = dataGrabber.getWeather();
            Console.WriteLine(t.ToString());
            Console.ReadKey();
        }
    }
}
