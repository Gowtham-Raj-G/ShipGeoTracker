﻿namespace ShipGeoTracker.Api.Infrastructure.Models
{
    public class PortResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsActive { get; set; }
    }
}
