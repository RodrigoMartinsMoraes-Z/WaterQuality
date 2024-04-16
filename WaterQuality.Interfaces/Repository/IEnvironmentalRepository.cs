using WaterQuality.Domain.Environment;

namespace WaterQuality.Interfaces.Repository;
public interface IEnvironmentalRepository
{
    Task<ICollection<EnvironmentalParameter>> Get();
    Task<ICollection<EnvironmentalParameter>> Get(DateTime date);
    Task Save(EnvironmentalParameter environmental);
}