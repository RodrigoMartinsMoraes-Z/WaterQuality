using WaterQuality.Domain.Water;

namespace WaterQuality.Interfaces.Repository;
public interface IWaterQualityRepository
{
    Task<ICollection<WaterQualityParameter>> GetAsync(CancellationToken cancellationToken = default);
    Task<ICollection<WaterQualityParameter>> GetAsync(DateTime date, CancellationToken cancellationToken = default);
    Task SaveAsync(WaterQualityParameter waterQuality, CancellationToken cancellationToken = default);
}
