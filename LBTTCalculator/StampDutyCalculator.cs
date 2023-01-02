public class StampDutyCalculator
{
    private readonly List<TaxBand> _taxBands;
    private readonly int _housePrice;

    public StampDutyCalculator(List<TaxBand> taxBands, int housePrice)
    {
        _housePrice = housePrice;
        _taxBands = taxBands;
    }

    public double CalculateStampDuty()
    {
        var stampDuty = 0.0;

        _taxBands.ForEach(band =>
        {
            if (_housePrice > band.HigherBound)
            {
                stampDuty += (band.HigherBound - band.LowerBound) * band.TaxRate;
            }
            else if (_housePrice >= band.LowerBound && _housePrice < band.HigherBound)
            {
                stampDuty += (_housePrice - band.LowerBound) * band.TaxRate;
            }
        });

        return Math.Round(stampDuty);
    }
}