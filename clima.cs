using System;

namespace EspacioClima
{
    public class Current
    {
        public string? time { get; set; }
        public int interval { get; set; }
        public double temperature_2m { get; set; }
        public double apparent_temperature { get; set; }
        public int is_day { get; set; }
        public double rain { get; set; }
        public int weather_code { get; set; }

    }

    public class CurrentUnits
    {
        public string? time { get; set; }
        public string? interval { get; set; }
        public string? temperature_2m { get; set; }
        public string? apparent_temperature { get; set; }
        public string? is_day { get; set; }
        public string? rain { get; set; }
        public string? weather_code { get; set; }
    }

    public class Clima
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double generationtime_ms { get; set; }
        public int utc_offset_seconds { get; set; }
        public string? timezone { get; set; }
        public string? timezone_abbreviation { get; set; }
        public double elevation { get; set; }
        public CurrentUnits? current_units { get; set; }
        public Current? current { get; set; }

       
    }




}