using WaterQuality.Domain.Environment;

namespace WaterQuality.Interfaces.Repository;
public interface IEnvironmentalRepository
{
    Task<ICollection<EnvironmentalParameter>> GetAsync(CancellationToken cancellationToken = default);
    Task<ICollection<EnvironmentalParameter>> GetAsync(DateTime date, CancellationToken cancellationToken = default);
    Task SaveAsync(EnvironmentalParameter environmental, CancellationToken cancellationToken = default);
}
