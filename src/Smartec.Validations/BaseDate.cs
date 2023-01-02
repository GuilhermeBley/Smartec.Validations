using System.Diagnostics.CodeAnalysis;

namespace Smartec.Validations;

public struct BaseDate : IConvertible, IComparable, IComparable<BaseDate>, IEquatable<BaseDate>, ISpanFormattable, IFormattable
{
    public const int ConstDay = 1;
    private static readonly BaseDate _minBaseDate = new BaseDate(DateTime.MinValue.Month, DateTime.MinValue.Year);
    private static readonly BaseDate _maxBaseDate = new BaseDate(DateTime.MaxValue.Month, DateTime.MaxValue.Year);
    private static BaseDate _now => new BaseDate(DateTime.Now.Month, DateTime.Now.Year);
    public static BaseDate MinBaseDate => _minBaseDate;
    public static BaseDate MaxBaseDate => _maxBaseDate;
    public static BaseDate Now => _now;

    private readonly DateTime _date = DateTime.MinValue;

    private readonly int _day => ConstDay;
    private readonly int _month => _date.Month;
    private readonly int _year => _date.Year;

    public int Day => _day;
    public int Month => _month;
    public int Year => _year;

    /// <summary>
    /// Initializes with min value
    /// </summary>
    public BaseDate()
    {
    }

    /// <summary>
    /// Initializes with month and year
    /// </summary>
    /// <param name="month">month</param>
    /// <param name="year">year</param>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public BaseDate(int month, int year)
    {
        _date = new DateTime(ConstDay, month, year);
    }

    /// <summary>
    /// Initializes with datetime
    /// </summary>
    public BaseDate(DateTime baseDate)
        : this(baseDate.Month, baseDate.Year)
    {
    }

    /// <summary>
    /// Type of struct
    /// </summary>
    /// <returns><see cref="TypeCode.DateTime"/></returns>
    public TypeCode GetTypeCode()
    {
        return TypeCode.DateTime;
    }

    /// <summary>
    /// Date of the current obj
    /// </summary>
    /// <param name="provider">format provider</param>
    public DateTime ToDateTime(IFormatProvider? provider)
    {
        return ToDateTime();
    }

    /// <summary>
    /// Date of the current obj
    /// </summary>
    public DateTime ToDateTime()
    {
        return _date;
    }

    /// <summary>
    /// Current ticks of date
    /// </summary>
    /// <param name="provider">format</param>
    /// <returns>ticks</returns>
    public long ToInt64(IFormatProvider? provider)
    {
        return _date.Ticks;
    }

    /// <summary>
    /// Current date to string with format
    /// </summary>
    /// <param name="provider">format</param>
    /// <returns>current date</returns>
    public string ToString(IFormatProvider? provider)
    {
        return _date.ToString(provider);
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        var objBaseDate = obj as BaseDate?;

        if (objBaseDate is null)
            return false;

        return _date.Equals(objBaseDate.Value.ToDateTime());
    }

    public override int GetHashCode()
    {
        return _date.GetHashCode();
    }

    public object ToType(Type conversionType, IFormatProvider? provider)
    {
        if (this.GetType().Equals(conversionType) 
            || conversionType.Equals(typeof(object)))
            return this;

        if (conversionType.Equals(typeof(DateTime)))
            return ToDateTime(provider);

        if (conversionType.Equals(typeof(long)))
            return ToInt64(provider);

        throw new ArgumentException("Invalid type.", $"{nameof(conversionType)}");
    }

    public object ToType(Type conversionType)
    {
        return ToType(conversionType, null);
    }

    public override string ToString()
    {
        return _date.ToString();
    }

    public string ToString(string? format)
    {
        return _date.ToString(format);
    }

    public string ToString(string? format, IFormatProvider? provider)
    {
        return _date.ToString(format, provider);
    }

    public int CompareTo(object? obj)
    {
        return _date.CompareTo(obj);
    }

    public int CompareTo(BaseDate other)
    {
        return _date.CompareTo(other.ToDateTime());
    }

    public bool Equals(BaseDate other)
    {
        return _date.Equals(other.ToDateTime());
    }

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        return _date.TryFormat(destination, out charsWritten, format, provider);
    }

    public static bool operator ==(BaseDate d1, BaseDate d2)
    {
        return d1.ToDateTime() == d2.ToDateTime();
    }

    public static bool operator !=(BaseDate d1, BaseDate d2)
    {
        return d1.ToDateTime() != d2.ToDateTime();
    }

    public static bool operator <(BaseDate t1, BaseDate t2)
    {
        return t1.ToDateTime() < t2.ToDateTime();
    }

    public static bool operator >(BaseDate t1, BaseDate t2)
    {
        return t1.ToDateTime() > t2.ToDateTime();
    }

    public static bool operator <=(BaseDate t1, BaseDate t2)
    {
        return t1.ToDateTime() <= t2.ToDateTime();
    }

    public static bool operator >=(BaseDate t1, BaseDate t2)
    {
        return t1.ToDateTime() >= t2.ToDateTime();
    }

    #region Obsolete

    [Obsolete("Invalid conversion.", true)]
    public ushort ToUInt16(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    [Obsolete("Invalid conversion.", true)]
    public uint ToUInt32(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    [Obsolete("Invalid conversion.", true)]
    public ulong ToUInt64(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    [Obsolete("Invalid conversion.", true)]
    public bool ToBoolean(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    [Obsolete("Invalid conversion.", true)]
    public decimal ToDecimal(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    [Obsolete("Invalid conversion.", true)]
    public double ToDouble(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    [Obsolete("Invalid conversion.", true)]
    public short ToInt16(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    [Obsolete("Invalid conversion.", true)]
    public int ToInt32(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    [Obsolete("Invalid conversion.", true)]
    public sbyte ToSByte(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    [Obsolete("Invalid conversion.", true)]
    public float ToSingle(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    [Obsolete("Invalid conversion.", true)]
    public byte ToByte(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    [Obsolete("Invalid conversion.", true)]
    public char ToChar(IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    #endregion
}
