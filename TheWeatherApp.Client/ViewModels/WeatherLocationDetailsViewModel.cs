namespace TheWeatherApp.Client.ViewModels
{
    public class WeatherLocationDetailsViewModel
    {
        public string Type { get; set; }

        public string Icon
        {
            set
            {
                // Append the icon code to the Url endpoint
                IconUrl = $"https://openweathermap.org/img/wn/{value}@2x.png";
            }
        }

        public string IconUrl { get; private set; }

        public double CurrentTempC { get; set; }

        public double CurrentTempF
        {
            get => CelsiusToFahrenheit(CurrentTempC);
        }

        public double FeelsLikeTempC { get; set; }

        public double FeelsLikeTempF
        {
            get => CelsiusToFahrenheit(FeelsLikeTempC);
        }

        public double MinTempC { get; set; }

        public double MinTempF
        {
            get => CelsiusToFahrenheit(MinTempC);
        }

        public double MaxTempC { get; set; }

        public double MaxTempF
        {
            get => CelsiusToFahrenheit(MaxTempC);
        }

        public double Pressure { get; set; }

        public double Humidity { get; set; }

        public double Sunrise
        {
            set
            {
                // This value is a unix time stamp, so get the time as a string from this
                SunriseTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(value).ToLocalTime().ToShortTimeString();
            }
        }

        public double Sunset
        {
            set
            {
                // This value is a unix time stamp, so get the time as a string from this
                SunsetTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(value).ToLocalTime().ToShortTimeString();
            }
        }

        public string SunriseTime { get; private set; }

        public string SunsetTime  { get; private set; }

        #region Methods

        public double CelsiusToFahrenheit(double c) =>
            ((c * 9) / 5) + 32;

        #endregion
    }
}