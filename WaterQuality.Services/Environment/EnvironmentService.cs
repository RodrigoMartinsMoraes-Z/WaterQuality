using WaterQuality.Domain.Environment;
using WaterQuality.Interfaces.Services;
using WaterQuality.Repository.Environment;

namespace WaterQuality.Services.Environment;
public class EnvironmentService(EnvironmentalRepository repository) : IEnvironmentService
{
    public async Task<ICollection<EnvironmentalParameter>> Get() => await repository.Get();

    public async Task<ICollection<EnvironmentalParameter>> GetRealtime() => await repository.Get(DateTime.Now);

    public async Task<ICollection<EnvironmentalParameter>> GetCurrentDay() => await repository.Get(DateTime.Today);

    public async Task<ICollection<EnvironmentalParameter>> GetFromDay(DateTime date) => await repository.Get(date);

    public async Task Save(EnvironmentalParameter parameter) => await repository.Save(parameter);
}
