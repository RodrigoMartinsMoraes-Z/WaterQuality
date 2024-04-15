namespace WaterQuality.Domain.Water;
public record WaterQualityParameter(long Id, int Tds, decimal Temperature, decimal Ph)
{
    public DateTime Date { get; } = DateTime.Now;
}
