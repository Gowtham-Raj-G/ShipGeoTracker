using ShipGeoTracker.Api.Infrastructure.Models;

namespace ShipGeoTracker.Api.Services.Interfaces
{
    public interface IShipService
    {
        Task<ShipResponseModel> AddAsync(ShipRequestModel shipRequestModel);
        Task<List<ShipResponseModel>> GetAllAsync();
        Task<ShipResponseModel> UpdateAsync(Guid id, ShipUpdateRequestModel shipUpdateRequestModel);
        Task<ClosestPortResponseModel?> GetClosestPortAsync(Guid id);
    }
}
