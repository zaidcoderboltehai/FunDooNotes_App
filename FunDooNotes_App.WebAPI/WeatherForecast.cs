namespace FunDooNotes_App.WebAPI
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; } // Ye property date ko store karegi

        public int TemperatureC { get; set; } // Temperature Celsius me store hoga

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556); // Celsius ko Fahrenheit me convert kar raha hai

        public string? Summary { get; set; } // Weather ka short description store karega (e.g., "Sunny", "Cold")
    }
}
