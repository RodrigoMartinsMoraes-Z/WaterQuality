using WaterQuality.Domain.Water;

namespace WaterQuality.Interfaces.Repository;
public interface IWaterQualityRepository
{
    Task<ICollection<WaterQualityParameter>> Get();
    Task<ICollection<WaterQualityParameter>> Get(DateTime date);
    Task Save(WaterQualityParameter waterQuality);
}