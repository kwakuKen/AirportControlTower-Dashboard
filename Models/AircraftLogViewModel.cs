namespace ControlTowerDashboard.Models;

public class AircraftLogViewModel
{

    public string callSign { get; set; }
    public Log[] logs { get; set; }
}

public class Log
{
    public string state { get; set; }
    public string outcome { get; set; }
    public string reason { get; set; }
    public DateTime createdAt { get; set; }
}