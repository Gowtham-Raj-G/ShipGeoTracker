using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShipGeoTracker.Api.Infrastructure.Models;
using ShipGeoTracker.Api.Services.Interfaces;
using ShipGeoTracker.Database;
using ShipGeoTracker.Database.Entities;

namespace ShipGeoTracker.Api.Services
{
    public class ShipService : IShipService
    {
        private readonly ShipGeoTrackerContext shipGeoTrackerContext;
        private readonly IPortService portService;
        private IMapper mapper;

        public ShipService(ShipGeoTrackerContext shipGeoTrackerContext, IMapper mapper, IPortService portService)
        {
            this.shipGeoTrackerContext = shipGeoTrackerContext;
            this.mapper = mapper;
            this.portService = portService;
        }

        public async Task<ShipResponseModel> AddAsync(ShipRequestModel shipRequestModel)
        {
            var ship = new Ship();

            if (shipRequestModel != null)
            {
                mapper.Map(shipRequestModel, ship);
                ship.Id = Guid.NewGuid();
                ship.IsActive = true;
                await shipGeoTrackerContext.Ships.AddAsync(ship);
                await shipGeoTrackerContext.SaveChangesAsync();
            }

            return mapper.Map<ShipResponseModel>(ship);
        }

        public async Task<List<ShipResponseModel>> GetAllAsync()
        {
            var ships = await shipGeoTrackerContext.Ships.Where(s => s.IsActive).ToListAsync();

            return mapper.Map<List<ShipResponseModel>>(ships.OrderBy(s => s.Name));
        }

        public async Task<ShipResponseModel> UpdateAsync(Guid id, ShipUpdateRequestModel shipUpdateRequestModel)
        {
            var ship = new Ship();

            if (shipUpdateRequestModel != null && id != Guid.Empty)
            {
                ship = await shipGeoTrackerContext.Ships.FirstOrDefaultAsync(s => s.Id == id && s.IsActive);

                if (ship != null)
                {
                    mapper.Map(shipUpdateRequestModel, ship);
                    shipGeoTrackerContext.Ships.Update(ship);
                    await shipGeoTrackerContext.SaveChangesAsync();
                }
            }

            return mapper.Map<ShipResponseModel>(ship);
        }

        public async Task<ClosestPortResponseModel?> GetClosestPortAsync(Guid id)
        {
            var responseModel = new ClosestPortResponseModel();

            if (id != Guid.Empty)
            {
                var ship = await shipGeoTrackerContext.Ships.FirstOrDefaultAsync(s => s.Id == id);

                if (ship == null)
                {
                    return null;
                }

                var ports = await portService.GetAllAsync();

                if (ports.Any())
                {

                    Dictionary<Guid, double> portDistances = new Dictionary<Guid, double>();

                    foreach (var port in ports)
                    {
                        double distance = CalculateDistance(ship.Latitude, ship.Longitude, port.Latitude, port.Longitude);
                        portDistances.Add(port.Id, distance);
                    }

                    // get the port with the shortest distance
                    Guid closestPortId = portDistances.OrderBy(x => x.Value).First().Key;

                    var closestPort = await portService.GetByIdAsync(closestPortId);

                    responseModel.PortName = closestPort.Name;
                    responseModel.Distance = portDistances[closestPortId];
                    responseModel.EstimatedArrivalTime = portDistances[closestPortId] / ship.Velocity;
                    responseModel.Latitude = closestPort.Latitude;
                    responseModel.Longitude = closestPort.Longitude;

                    return responseModel;
                }

            }

            return responseModel;
        }

        private double CalculateDistance(double firstLatitude, double firstLongitude, double secondLatitude, double secondLongitude)
        {
            // Haversine formula to calculate the distance between two points on the Earth's surface

            double earthRadius = 6371; // Earth's radius in kilometers

            double dLat = ToRadians(secondLatitude - firstLatitude);
            double dLon = ToRadians(secondLongitude - firstLongitude);

            double calculatedAngle = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(ToRadians(firstLatitude)) * Math.Cos(ToRadians(secondLatitude)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double angle = 2 * Math.Atan2(Math.Sqrt(calculatedAngle), Math.Sqrt(1 - calculatedAngle));

            return earthRadius * angle;
        }

        private double ToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
    }
}
