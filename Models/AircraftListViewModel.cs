namespace ControlTowerDashboard.Models;

public class AircraftListViewModel
{
        public string callSign { get; set; }
        public string type { get; set; }
        public string state { get; set; }
        public object latitude { get; set; }
        public object longitude { get; set; }
        public object altitude { get; set; }
        public object heading { get; set; }
        public DateTime createdAt { get; set; }

}
