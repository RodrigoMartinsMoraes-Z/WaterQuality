namespace WaterQuality.Domain.Environment;
public record EnvironmentalParameter(decimal Temperature = 0, decimal Humidity = 0, DateTime Date = default);
