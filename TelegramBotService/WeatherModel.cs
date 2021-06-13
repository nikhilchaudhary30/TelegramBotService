using System;
using System.Collections.Generic;

namespace TelegramBotService
{
    public partial class Temperatures
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
        public Forecast forecast { get; set; }
    }

    public partial class Current
    {
        public string last_updated { get; set; }
        public string last_updated_epoch { get; set; }
        public decimal temp_c { get; set; }
        public decimal temp_f { get; set; }
        public int? is_day { get; set; }
        public Condition condition { get; set; }
        public decimal? wind_mph { get; set; }
        public decimal? wind_kph { get; set; }
        public int? wind_degree { get; set; }
        public string wind_dir { get; set; }
        public decimal? pressure_mb { get; set; }
        public decimal? pressure_in { get; set; }
        public decimal? precip_mm { get; set; }
        public decimal? precip_in { get; set; }
        public int? humidity { get; set; }
        public int? cloud { get; set; }
        public decimal? feelslike_c { get; set; }
        public decimal? feelslike_f { get; set; }
        public decimal? vis_km { get; set; }
        public decimal? vis_miles { get; set; }
        public decimal? uv { get; set; }
        public decimal? gust_mph { get; set; }
        public decimal? gust_kph { get; set; }
        public AirQuality air_quality { get; set; }
    }

    public partial class AirQuality
    {
        public float co { get; set; }
        public float no2 { get; set; }
        public float o3 { get; set; }
        public float so2 { get; set; }
        public float pm2_5 { get; set; }
        public float pm10 { get; set; }
    }

    public partial class Condition
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public int? Code { get; set; }
    }

    public partial class Forecast
    {
        public List<Forecastday> Forecastday { get; set; }
    }

    public partial class Forecastday
    {
        public string date { get; set; }
        public int? date_epoch { get; set; }
        public Day day { get; set; }
        public Astro astro { get; set; }
        public Hour hour { get; set; }
    }

    public partial class Astro
    {
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string moonrise { get; set; }
        public string moonset { get; set; }
        public string moon_phase { get; set; }
        public int? moon_illumination { get; set; }
    }

    public partial class Day
    {
        public decimal? maxtemp_c { get; set; }
        public decimal? maxtemp_f { get; set; }
        public decimal? mintemp_c { get; set; }
        public decimal? mintemp_f { get; set; }
        public decimal? avgtemp_c { get; set; }
        public decimal? avgtemp_f { get; set; }
        public decimal? maxwind_mph { get; set; }
        public decimal? maxwind_kph { get; set; }
        public decimal? totalprecip_mm { get; set; }
        public decimal? totalprecip_in { get; set; }
        public int? avgvis_km { get; set; }
        public int? avgvis_miles { get; set; }
        public int? avghumidity { get; set; }
        public int? DailyWillItRain { get; set; }
        public int? Dailychance_of_rain { get; set; }
        public int? DailyWillItSnow { get; set; }
        public int? Dailychance_of_snow { get; set; }
        public Condition condition { get; set; }
        public int? uv { get; set; }
    }

    public partial class Hour
    {
        public int? time_epoch { get; set; }
        public string time { get; set; }
        public decimal? temp_c { get; set; }
        public decimal? temp_f { get; set; }
        public int? is_day { get; set; }
        public Condition condition { get; set; }
        public decimal? wind_mph { get; set; }
        public decimal? wind_kph { get; set; }
        public int? wind_degree { get; set; }
        public string wind_dir { get; set; }
        public decimal? pressure_mb { get; set; }
        public decimal? pressure_in { get; set; }
        public decimal? precip_mm { get; set; }
        public decimal? precip_in { get; set; }
        public int? humidity { get; set; }
        public int? cloud { get; set; }
        public decimal? feelslike_c { get; set; }
        public decimal? feelslike_f { get; set; }
        public decimal? windchill_c { get; set; }
        public decimal? windchill_f { get; set; }
        public decimal? heatindex_c { get; set; }
        public decimal? heatindex_f { get; set; }
        public decimal? dewpoint_c { get; set; }
        public decimal? dewpoint_f { get; set; }
        public int? will_it_rain { get; set; }
        public int? chance_of_rain { get; set; }
        public int? will_it_snow { get; set; }
        public int? chance_of_snow { get; set; }
        public decimal? vis_km { get; set; }
        public int? vis_miles { get; set; }
        public decimal? gust_mph { get; set; }
        public decimal? gust_kph { get; set; }
        public int? uv { get; set; }
    }

    public partial class Location
    {
        public string Name { get; set; }
        public string region { get; set; }
        public string Country { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Lon { get; set; }
        public string tz_id { get; set; }
        public int? localtime_epoch { get; set; }
        public string Localtime { get; set; }
    }
}
