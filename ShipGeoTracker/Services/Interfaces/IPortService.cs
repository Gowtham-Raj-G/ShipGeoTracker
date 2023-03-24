using ShipGeoTracker.Api.Infrastructure.Models;

namespace ShipGeoTracker.Api.Services.Interfaces
{
    public interface IPortService
    {
        Task<List<PortResponseModel>> GetAllAsync();

        Task<PortResponseModel> GetByIdAsync(Guid id);
    }
}
