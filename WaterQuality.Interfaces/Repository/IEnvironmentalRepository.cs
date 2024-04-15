using WaterQuality.Domain.Environment;

namespace WaterQuality.Interfaces.Repository;
public interface IEnvironmentalRepository
{
    Task<ICollection<EnvironmentalParameter>> Get();
    Task<EnvironmentalParameter> Get(DateTime date);
    Task Save(EnvironmentalParameter environmental);
}