namespace WaterQuality.Domain.Environment;
public record EnvironmentalParameter(decimal Temperature, decimal Humidity)
{
    public DateTime Date { get; } = DateTime.Now;
}
