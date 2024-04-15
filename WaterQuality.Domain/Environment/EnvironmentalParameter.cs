namespace WaterQuality.Domain.Environment;
public record EnvironmentalParameter(long Id, decimal Temperature, decimal Humidity)
{
    public DateTime Date { get; } = DateTime.Now;
}
