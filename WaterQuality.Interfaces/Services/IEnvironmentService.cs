using WaterQuality.Common.Response;
using WaterQuality.Domain.Environment;

namespace WaterQuality.Interfaces.Services;

public interface IEnvironmentService
{
    Task<DefaultResponse> GetAsync(CancellationToken cancellationToken = default);
    Task<DefaultResponse> GetCurrentDayAsync(CancellationToken cancellationToken = default);
    Task<DefaultResponse> GetFromDayAsync(DateTime date, CancellationToken cancellationToken = default);
    Task<DefaultResponse> GetRealtimeAsync(CancellationToken cancellationToken = default);
    Task<DefaultResponse> SaveAsync(EnvironmentalParameter parameter, CancellationToken cancellationToken = default);
}
