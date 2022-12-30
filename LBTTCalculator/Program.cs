public record TaxBand(double TaxRate, int LowerBound, int HigherBound);

internal class Program
{
    private static StampDutyCalculator? stampDutyCalculator;
    private static List<TaxBand> taxBands = new()
    {
        new TaxBand(0.0, 0, 145000),
        new TaxBand(0.02, 145001, 250000),
        new TaxBand(0.05, 250001, 325000),
        new TaxBand(0.1, 325001, 750000),
        new TaxBand(0.12, 750001, 10000000)
    };

    private static void Main()
    {
        var housePrice = Convert.ToInt32(Console.ReadLine());
        stampDutyCalculator = new(taxBands, housePrice);
        Console.WriteLine(stampDutyCalculator.calculateStampDuty());
    }
}