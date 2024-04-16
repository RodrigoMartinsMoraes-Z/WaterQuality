using WaterQuality.Domain.Environment;
using WaterQuality.Interfaces.Repository;
using WaterQuality.Interfaces.Services;

namespace WaterQuality.Services.Environment;
public class EnvironmentService(IEnvironmentalRepository repository) : IEnvironmentService
{
    private readonly IEnvironmentalRepository _repository = repository;

    public async Task<ICollection<EnvironmentalParameter>> Get() => await _repository.Get();

    public async Task<ICollection<EnvironmentalParameter>> GetRealtime() => await _repository.Get(DateTime.Now);

    public async Task<ICollection<EnvironmentalParameter>> GetCurrentDay() => await _repository.Get(DateTime.Today);

    public async Task<ICollection<EnvironmentalParameter>> GetFromDay(DateTime date) => await _repository.Get(date);

    public async Task Save(EnvironmentalParameter parameter) => await _repository.Save(parameter);
}
