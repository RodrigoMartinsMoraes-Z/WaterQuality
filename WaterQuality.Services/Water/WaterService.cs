using WaterQuality.Domain.Water;
using WaterQuality.Interfaces.Repository;
using WaterQuality.Interfaces.Services;

namespace WaterQuality.Services.Water;
public class WaterService(IWaterQualityRepository repository) : IWaterService
{
    private readonly IWaterQualityRepository _repository = repository;

    public async Task<ICollection<WaterQualityParameter>> Get() => await _repository.Get();

    public async Task<ICollection<WaterQualityParameter>> GetRealtime() => await _repository.Get(DateTime.Now);

    public async Task<ICollection<WaterQualityParameter>> GetCurrentDay() => await _repository.Get(DateTime.Today);

    public async Task<ICollection<WaterQualityParameter>> GetFromDay(DateTime date) => await _repository.Get(date);

    public async Task Save(WaterQualityParameter parameter) => await _repository.Save(parameter);
}
