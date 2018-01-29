using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;

namespace WeatherApp
{
    class CityManager
    {
        private JArray _Cities = new JArray();
        public CityManager(string CityListLocation)
        {
            string cities = File.ReadAllText(CityListLocation);
            _Cities = JArray.Parse(cities);
        }

        public string GetIdFromName(string name) {
            var cities = _Cities.Children().ToList();
            foreach(JObject t in cities)
            {
                if (t["name"].ToString().ToLower().Equals(name.ToLower()))
                    return t["id"].ToString();
            }
            return null;
        }
    }
}
