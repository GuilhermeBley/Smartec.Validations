using Smartec.Validations.Extensions.Text;

namespace Smartec.Validations.Tests;

public class StringExtensionTest
{
    private const string ENUMERATE_1_TO_10 = "1\n2\n3\n4\n5\n6\n7\n8\n9\n10";

    [Fact]
    public void GetBetween_CheckIfMiddleNumber_Success()
    {
        var onlyNumber7 = ENUMERATE_1_TO_10.GetBetween("6\n", "\n");

        Assert.Equal("7", onlyNumber7);
    }

    [Fact]
    public void GetBetween_CheckWithEmptyFirst_Failed()
    {
        var between = ENUMERATE_1_TO_10.GetBetween(string.Empty, "\n");

        Assert.Equal(string.Empty, between);
    }

    [Fact]
    public void GetBetween_CheckWithEmptyLastAndGetNumber_Success()
    {
        var onlyNumber9And10 = ENUMERATE_1_TO_10.GetBetween("8\n", string.Empty);

        Assert.Equal("9\n10", onlyNumber9And10);
    }

    [Fact]
    public void GetBetween_CheckWithLastBeforeFirst_Failed()
    {
        var onlyNumber7 = ENUMERATE_1_TO_10.GetBetween("8\n", "6\n");

        Assert.Equal(string.Empty, onlyNumber7);
    }
}