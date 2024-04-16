using WaterQuality.Domain.Environment;

namespace WaterQuality.Interfaces.Services;
public interface IEnvironmentService
{
    Task<ICollection<EnvironmentalParameter>> Get();
    Task<ICollection<EnvironmentalParameter>> GetCurrentDay();
    Task<ICollection<EnvironmentalParameter>> GetFromDay(DateTime date);
    Task<ICollection<EnvironmentalParameter>> GetRealtime();
    Task Save(EnvironmentalParameter parameter);
}