using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShipGeoTracker.Api.Infrastructure.Models;
using ShipGeoTracker.Api.Services.Interfaces;
using ShipGeoTracker.Database;

namespace ShipGeoTracker.Api.Services
{
    public class PortService : IPortService
    {
        private readonly ShipGeoTrackerContext shipGeoTrackerContext;
        private IMapper mapper;

        public PortService(ShipGeoTrackerContext shipGeoTrackerContext, IMapper mapper)
        {
            this.shipGeoTrackerContext = shipGeoTrackerContext;
            this.mapper = mapper;
        }

        public async Task<List<PortResponseModel>> GetAllAsync()
        {
            var ports = await shipGeoTrackerContext.Ports.Where(s => s.IsActive).ToListAsync();

            return mapper.Map<List<PortResponseModel>>(ports.OrderBy(s => s.Name));
        }

        public async Task<PortResponseModel> GetByIdAsync(Guid id)
        {
            var port = await shipGeoTrackerContext.Ports.FirstOrDefaultAsync(p => p.Id == id && p.IsActive);

            return mapper.Map<PortResponseModel>(port);
        }
    }
}
