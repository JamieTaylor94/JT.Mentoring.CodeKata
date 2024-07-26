using Xunit;
namespace JT.Mentoring.CodeKata.Tests;

public class BookCalculatorTests
{
    private readonly BookCalculator _bookCalculator;

    public BookCalculatorTests()
    {
        _bookCalculator = new BookCalculator();
    }

    [Fact]
    public void No_Books_Cost_Nothing()
    {
        var result = _bookCalculator.Calculate([]);

        Assert.Equal(0, result);
    }

    [Fact]
    public void One_Book_Costs_EightEuros()
    {
        var result = _bookCalculator.Calculate(["one"]);

        Assert.Equal(8, result);
    }

    [Fact]
    public void Two_Identical_Books_Cost_SixteenEuros()
    {
        var result = _bookCalculator.Calculate(["one", "one"]);

        Assert.Equal(16, result);
    }

    [Fact]
    public void Two_Different_Books_Have_Five_Percent_Discount()
    {
        var result = _bookCalculator.Calculate(["one", "two"]);

        Assert.Equal(15.2m, result);
    }

    [Fact]
    public void Three_Different_Books_Ten_Percent_Discount()
    {
        var result = _bookCalculator.Calculate(["one", "two", "three"]);

        Assert.Equal(21.6m, result);
    }

    [Fact]
    public void Four_Different_Books_Twenty_Percent_Discount()
    {
        var result = _bookCalculator.Calculate(["one", "two", "three", "four"]);

        Assert.Equal(25.6m, result);
    }

    [Fact]
    public void Five_Different_Books_Twenty_Five_Percent_Discount()
    {
        var result = _bookCalculator.Calculate(["one", "two", "three", "four", "five"]);

        Assert.Equal(30, result);
    }

    [Fact]
    public void Two_Different_Books_Five_Percent_Discount_One_Is_FullPrice()
    {
        var result = _bookCalculator.Calculate(["one", "one", "two"]);

        Assert.Equal(23.2m, result);
    }

    [Fact]
    public void Two_Sets_Have_Ten_Percent_Discount_Each()
    {
        var result = _bookCalculator.Calculate(["one", "one", "two", "two"]);

        Assert.Equal(30.4m, result);
    }

    [Fact]
    public void The_Answer()
    {
        var result = _bookCalculator.Calculate(["one", "one", "two", "two", "three", "three", "four", "five"]);

        Assert.Equal(51.60m, result);
    }
}
