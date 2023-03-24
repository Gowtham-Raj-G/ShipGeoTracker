namespace ShipGeoTracker.Database.Entities
{
    public class Ship
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Velocity { get; set; }
        public bool IsActive { get; set; }
    }
}
