namespace ControlTowerDashboard.Models;

public class DashboardViewModel
{
    public WeatherDetailsViewModel Weather { get; set; } = new WeatherDetailsViewModel();
    public ParkingSpotViewModel[]? Parking { get; set; } 
    public FlightLogsViewModel[]? Logs { get; set; }
}

public class WeatherDetailsViewModel
{
    public string? description { get; set; }
    public float temperature { get; set; }
    public int visibility { get; set; }
    public float windSpeed { get; set; }
    public int windDirection { get; set; }
    public int id { get; set; }
    public DateTime createdAt { get; set; }
}

public class ParkingSpotViewModel
{
    public int id { get; set; }
    public string type { get; set; }
    public bool isOccupied { get; set; }
    public string callSign { get; set; }
    public object aircraft { get; set; }

}

public class FlightLogsViewModel
{
    public string callSign { get; set; }
    public string state { get; set; }
    public bool isAccepted { get; set; }
    public string reason { get; set; }
    public int id { get; set; }
    public DateTime createdAt { get; set; }
}