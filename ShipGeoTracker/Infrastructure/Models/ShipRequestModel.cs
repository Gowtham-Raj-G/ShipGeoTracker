using System.ComponentModel.DataAnnotations;

namespace ShipGeoTracker.Api.Infrastructure.Models
{
    public class ShipRequestModel
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Velocity { get; set; }
    }
}
