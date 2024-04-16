using WaterQuality.Domain.Water;

namespace WaterQuality.Interfaces.Services;
public interface IWaterService
{
    Task<ICollection<WaterQualityParameter>> Get();
    Task<ICollection<WaterQualityParameter>> GetCurrentDay();
    Task<ICollection<WaterQualityParameter>> GetFromDay(DateTime date);
    Task<ICollection<WaterQualityParameter>> GetRealtime();
    Task Save(WaterQualityParameter parameter);
}