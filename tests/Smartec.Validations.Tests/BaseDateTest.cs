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

    [Fact]
    public void MinBaseDate_CheckIfIsEqualMinDateInCtor_Success()
    {
        BaseDate? bdate = BaseDate.MinBaseDate;
        Assert.Equal(new BaseDate(), bdate);
    }

    [Fact]
    public void MinBaseDate_CheckIfIsEqualNullableMinDate_Success()
    {
        BaseDate? bdateStaticProp = BaseDate.MinBaseDate;
        BaseDate? bDateNewInstance = new BaseDate();
        Assert.Equal(bdateStaticProp, bDateNewInstance);
    }

    [Fact]
    public void MinBaseDate_CheckIfIsEqualNull_Failed()
    {
        BaseDate? bdate = BaseDate.MinBaseDate;
        Assert.NotNull(bdate);
    }
    
    [Fact]
    public void MinBaseDate_CheckIfIsEqualNewInstanceMinDateTime_Success()
    {
        BaseDate? bdate = BaseDate.MinBaseDate;
        Assert.Equal(new BaseDate(DateTime.MinValue.Year, DateTime.MinValue.Month), bdate);
    }
    
    [Fact]
    public void MaxBaseDate_CheckIfIsEqualNewInstanceMinDateTime_Success()
    {
        BaseDate? bdate = BaseDate.MaxBaseDate;
        Assert.Equal(new BaseDate(DateTime.MaxValue.Year, DateTime.MaxValue.Month), bdate);
    }

    [Fact]
    public void ToDateTime_TryConvert_Success()
    {
        BaseDate? bdate = BaseDate.Now;
        Assert.Equal(Convert.ToDateTime(bdate), bdate.Value.ToDateTime());
    }

    [Fact]
    public void ToBoolean_TryConvert_Failed()
    {
        BaseDate? bdate = BaseDate.Now;
        Assert.Throws<InvalidCastException>(
            () => Convert.ToBoolean(bdate));
    }

    [Fact]
    public void ToByte_TryConvert_Failed()
    {
        BaseDate? bdate = BaseDate.Now;
        Assert.Throws<InvalidCastException>(
            () => Convert.ToByte(bdate));
    }

    [Fact]
    public void ToChar_TryConvert_Failed()
    {
        BaseDate? bdate = BaseDate.Now;
        Assert.Throws<InvalidCastException>(
            () => Convert.ToChar(bdate));
    }

    [Fact]
    public void ToDecimal_TryConvert_Failed()
    {
        BaseDate? bdate = BaseDate.Now;
        Assert.Throws<InvalidCastException>(
            () => Convert.ToDecimal(bdate));
    }

    [Fact]
    public void ToDouble_TryConvert_Failed()
    {
        BaseDate? bdate = BaseDate.Now;
        Assert.Throws<InvalidCastException>(
            () => Convert.ToDouble(bdate));
    }

    [Fact]
    public void ToInt16_TryConvert_Failed()
    {
        BaseDate? bdate = BaseDate.Now;
        Assert.Throws<InvalidCastException>(
            () => Convert.ToInt16(bdate));
    }

    [Fact]
    public void ToInt32_TryConvert_Failed()
    {
        BaseDate? bdate = BaseDate.Now;
        Assert.Throws<InvalidCastException>(
            () => Convert.ToInt32(bdate));
    }

    [Fact]
    public void ToInt64_TryConvert_Failed()
    {
        BaseDate? bdate = new BaseDate();
        Convert.ToInt64(bdate);
    }

    [Fact]
    public void ToSByte_TryConvert_Failed()
    {
        BaseDate? bdate = BaseDate.Now;
        Assert.Throws<InvalidCastException>(
            () => Convert.ToSByte(bdate));
    }

    [Fact]
    public void ToSingle_TryConvert_Failed()
    {
        BaseDate? bdate = BaseDate.Now;
        Assert.Throws<InvalidCastException>(
            () => Convert.ToSingle(bdate));
    }

    [Fact]
    public void ToUInt16_TryConvert_Failed()
    {
        BaseDate? bdate = BaseDate.Now;
        Assert.Throws<InvalidCastException>(
            () => Convert.ToUInt16(bdate));
    }

    [Fact]
    public void ToUInt32_TryConvert_Failed()
    {
        BaseDate? bdate = BaseDate.Now;
        Assert.Throws<InvalidCastException>(
            () => Convert.ToUInt32(bdate));
    }

    [Fact]
    public void ToUInt64_TryConvert_Failed()
    {
        BaseDate? bdate = BaseDate.Now;
        Assert.Throws<InvalidCastException>(
            () => Convert.ToUInt64(bdate));
    }

    [Fact]
    public void ToString_TryConvert_Failed()
    {
        BaseDate? bdate = BaseDate.Now;
        Convert.ToString(bdate);
    }

    [Fact]
    public void CompareTo_NotEqualValueCompareWithDateTime_Success()
    {
        const int EqualCompare = 0;
        DateTime dtNow = DateTime.Now;
        BaseDate? bdate = new BaseDate(dtNow);
        Assert.NotEqual(EqualCompare, bdate.Value.CompareTo(dtNow));
    }

    [Fact]
    public void OperatorEqual_CheckDateTimeAndBaseDate_Success()
    {
        var operatorResult = DateTime.MinValue == BaseDate.Now;
        Assert.False(operatorResult);
    }

    [Fact]
    public void OperatorNotEqual_CheckDateTimeAndBaseDate_Success()
    {
        var operatorResult = DateTime.MinValue != BaseDate.Now;
        Assert.True(operatorResult);
    }

    [Fact]
    public void OperatorGreaterThan_CheckDateTimeAndBaseDate_Success()
    {
        var operatorResult = DateTime.MinValue > BaseDate.Now;
        Assert.False(operatorResult);
    }

    [Fact]
    public void OperatorLessThan_CheckDateTimeAndBaseDate_Success()
    {
        var operatorResult = DateTime.MinValue < BaseDate.Now;
        Assert.True(operatorResult);
    }

    [Fact]
    public void OperatorGreaterThanOrEqual_CheckDateTimeAndBaseDate_Success()
    {
        var operatorResult = DateTime.MaxValue >= BaseDate.Now;
        Assert.True(operatorResult);
    }

    [Fact]
    public void OperatorLessThanOrEqual_CheckDateTimeAndBaseDate_Success()
    {
        var operatorResult = DateTime.MinValue <= BaseDate.Now;
        Assert.True(operatorResult);
    }

    [Fact]
    public void OperatorEqual_CheckBaseDateAndDateTime_Success()
    {
        var dTime = new DateTime(2000, 1, 1);
        var bDate = new BaseDate(dTime);
        var operatorResult = bDate == dTime;
        Assert.True(operatorResult);
    }

    [Fact]
    public void OperatorNotEqual_CheckBaseDateAndDateTime_Success()
    {
        var operatorResult = BaseDate.Now != DateTime.MaxValue;
        Assert.True(operatorResult);
    }

    [Fact]
    public void OperatorGreaterThan_CheckBaseDateAndDateTime_Success()
    {
        var operatorResult = BaseDate.Now > DateTime.MinValue;
        Assert.True(operatorResult);
    }

    [Fact]
    public void OperatorLessThan_CheckBaseDateAndDateTime_Success()
    {
        var operatorResult = BaseDate.Now > DateTime.MinValue;
        Assert.True(operatorResult);
    }

    [Fact]
    public void OperatorGreaterThanOrEqual_CheckBaseDateAndDateTime_Success()
    {
        var operatorResult = BaseDate.Now  >= DateTime.MaxValue;
        Assert.False(operatorResult);
    }

    [Fact]
    public void OperatorLessThanOrEqual_CheckBaseDateAndDateTime_Success()
    {
        var dTime = new DateTime(2000, 1, 1);
        var bDate = new BaseDate(dTime);
        var operatorResult = bDate <= dTime;
        Assert.True(operatorResult);
    }

    [Fact]
    public void OperatorEqual_CheckBaseDate_Success()
    {
        var operatorResult = BaseDate.MinBaseDate == BaseDate.MinBaseDate;
        Assert.True(operatorResult);
    }

    [Fact]
    public void OperatorNotEqual_CheckBaseDate_Success()
    {
        var operatorResult = BaseDate.MinBaseDate != BaseDate.MaxBaseDate;
        Assert.True(operatorResult);
    }

    [Fact]
    public void OperatorGreaterThan_CheckBaseDate_Success()
    {
        var operatorResult = BaseDate.MinBaseDate > BaseDate.MaxBaseDate;
        Assert.False(operatorResult);
    }

    [Fact]
    public void OperatorLessThan_CheckBaseDate_Success()
    {
        var operatorResult = BaseDate.Now > BaseDate.MinBaseDate;
        Assert.True(operatorResult);
    }

    [Fact]
    public void OperatorGreaterThanOrEqual_CheckBaseDate_Success()
    {
        var operatorResult = BaseDate.Now  >= BaseDate.MaxBaseDate;
        Assert.False(operatorResult);
    }

    [Fact]
    public void OperatorLessThanOrEqual_CheckBaseDate_Success()
    {
        var operatorResult = BaseDate.Now  <= BaseDate.MaxBaseDate;
        Assert.True(operatorResult);
    }
}