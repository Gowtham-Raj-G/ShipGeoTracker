using System.ComponentModel.DataAnnotations;

namespace ShipGeoTracker.Api.Infrastructure.Models
{
    public class ShipUpdateRequestModel
    {
        [Required]
        public double Velocity { get; set; }
    }
}
