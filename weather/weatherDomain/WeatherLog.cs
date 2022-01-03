using System;
using System.Linq;
using System.Collections.Generic;

namespace weatherDomain
{
    public class WeatherLog
    {
        private List<WeatherDTO> weatherLog;

        public WeatherLog() {
            weatherLog = new List<WeatherDTO>();
        }

        public void Add(WeatherDTO weather) {
            var weatherStamp = weatherLog.FirstOrDefault(x => x.Date == weather.Date);
            if (weatherStamp == null)
            {
                weatherLog.Add(weather);
            }
        }

        public void Update(decimal tempreture, DateTime date) {
            var weatherStamp = weatherLog.FirstOrDefault(x => x.Date == date);
            if (weatherStamp != null)
            {
                weatherStamp.Tempreture = tempreture;
            }
        }

        public void Remove(WeatherDTO weather) {
            var weatherStamp = weatherLog.FirstOrDefault(x => x.Date == weather.Date);
            if (weatherStamp != null)
            {
                weatherLog.Remove(weatherStamp);
            }
        }

        public IEnumerable<WeatherDTO> Get(DateTime from, DateTime to) {
            var result = weatherLog.Where(x => x.Date >= from && x.Date <= to);
            return result;
        }
    }
}

