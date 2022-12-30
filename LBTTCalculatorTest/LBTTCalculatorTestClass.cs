namespace LBTTCalculatorTest;

public class LBTTCalculatorTestClass
{
    private List<TaxBand> taxBands = new()
    {
        new TaxBand(0.0, 0, 145000),
        new TaxBand(0.02, 145001, 250000),
        new TaxBand(0.05, 250001, 325000),
        new TaxBand(0.1, 325001, 750000),
        new TaxBand(0.12, 750001, 10000000)
    };

    [Fact]
    public void StampDuty_MiddleBand_ReturnsCorrectStampDuty()
    {
        // Arrange
        var housePrice = 500_000;
        double expectedStampDuty = 23_350;
        StampDutyCalculator stampDutyCalculator = new(taxBands, housePrice);

        // Act
        var stampDuty = stampDutyCalculator.calculateStampDuty();

        // Assert
        Assert.Equal(expectedStampDuty, stampDuty);
    }
}
