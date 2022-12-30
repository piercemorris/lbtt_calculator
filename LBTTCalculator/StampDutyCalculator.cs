public class StampDutyCalculator
{
    private List<TaxBand> _taxBands;
    private int _housePrice;

    public StampDutyCalculator(List<TaxBand> taxBands, int housePrice)
    {
        _housePrice = housePrice;
        _taxBands = taxBands;
    }

    public double calculateStampDuty()
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