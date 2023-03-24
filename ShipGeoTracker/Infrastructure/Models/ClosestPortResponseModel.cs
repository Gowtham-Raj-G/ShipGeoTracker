namespace ShipGeoTracker.Api.Infrastructure.Models
{
    public class ClosestPortResponseModel
    {
        public string PortName { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Distance { get; set; }
        public double EstimatedArrivalTime { get; set; }
    }
}
