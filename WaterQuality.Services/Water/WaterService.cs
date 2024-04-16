using WaterQuality.Domain.Water;
using WaterQuality.Interfaces.Services;
using WaterQuality.Repository.Water;

namespace WaterQuality.Services.Water;
public class WaterService(WaterQualityRepository repository) : IWaterService
{
    public async Task<ICollection<WaterQualityParameter>> Get() => await repository.Get();

    public async Task<ICollection<WaterQualityParameter>> GetRealtime() => await repository.Get(DateTime.Now);

    public async Task<ICollection<WaterQualityParameter>> GetCurrentDay() => await repository.Get(DateTime.Today);

    public async Task<ICollection<WaterQualityParameter>> GetFromDay(DateTime date) => await repository.Get(date);

    public async Task Save(WaterQualityParameter parameter) => await repository.Save(parameter);
}
