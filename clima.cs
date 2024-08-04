using System;

namespace EspacioClima
{
    public class Clima
    {
        public class Forecast
        {
            public string day { get; set; }
            public string temperature { get; set; }
            public string wind { get; set; }
        }

        public class Root
        {
            public string temperature { get; set; }
            public string wind { get; set; }
            public string description { get; set; }
            public List<Forecast> forecast { get; set; }
        }
    }
}