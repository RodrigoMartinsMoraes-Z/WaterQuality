using WaterQuality.Common.Response;
using WaterQuality.Domain.Water;

namespace WaterQuality.Interfaces.Services;

public interface IWaterService
{
    Task<DefaultResponse> GetAsync(CancellationToken cancellationToken = default);
    Task<DefaultResponse> GetCurrentDayAsync(CancellationToken cancellationToken = default);
    Task<DefaultResponse> GetFromDayAsync(DateTime date, CancellationToken cancellationToken = default);
    Task<DefaultResponse> GetRealtimeAsync(CancellationToken cancellationToken = default);
    Task<DefaultResponse> SaveAsync(WaterQualityParameter parameter, CancellationToken cancellationToken = default);
}
