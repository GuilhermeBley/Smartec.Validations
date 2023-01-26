namespace Smartec.Validations.Tests;

public class BaseDateTest
{
    [Fact]
    public void Create_CheckSameDateTime_Success()
    {
        var dtTime = new DateTime(1900, 1, 1);

        var baseDate = new BaseDate(dtTime);

        Assert.Equal(dtTime, baseDate.ToDateTime());
    }

    
    [Fact]
    public void Create_CheckSameYearAndMonth_Success()
    {
        const int year = 1900;
        const int month = 1;

        var baseDate = new BaseDate(year, month);

        Assert.Equal(year, baseDate.Year);
        Assert.Equal(month, baseDate.Month);
    }

    [Fact]
    public void Now_CheckIfIsValidDate_Success()
    {
        BaseDate? bdate = BaseDate.Now;
        Assert.NotNull(bdate);
    }
}