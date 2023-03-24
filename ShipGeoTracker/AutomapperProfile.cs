using AutoMapper;
using ShipGeoTracker.Api.Infrastructure.Models;
using ShipGeoTracker.Database.Entities;

namespace ShipGeoTracker.Api
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Ship, ShipResponseModel>();
            CreateMap<ShipRequestModel, Ship>();
            CreateMap<ShipUpdateRequestModel, Ship>();
            CreateMap<Port, PortResponseModel>();
        }
    }
}
