using Xunit;
using LoanApp.Core;

namespace LoanApp.Tests;

public class LoanEvaluatorTests
{
    [Fact]
    public void GetLoanEligibility_Should_Return_NotEligible_When_IncomeLow()
    {
        var result = LoanEvaluator.GetLoanEligibility(1500, true, 800, 5, true);
        Assert.Equal("Not Eligible", result);
    }

    [Fact]
    public void GetLoanEligibility_Should_Return_Eligible_When_CreditHigh_And_NoDependents()
    {
        var result = LoanEvaluator.GetLoanEligibility(3000, true, 750, 0, false);
        Assert.Equal("Eligible", result);
    }

    [Fact]
    public void GetLoanEligibility_Should_Return_Review_When_CreditHigh_And_2Dependents()
    {
        var result = LoanEvaluator.GetLoanEligibility(3000, true, 720, 2, false);
        Assert.Equal("Review Manually", result);
    }

    [Fact]
    public void GetLoanEligibility_Should_Return_Eligible_When_Unemployed_HighCredit_OwnsHouse()
    {
        var result = LoanEvaluator.GetLoanEligibility(6000, false, 780, 1, true);
        Assert.Equal("Eligible", result);
    }

    [Fact]
    public void GetLoanEligibility_Should_Return_Review_When_Unemployed_Credit650_And_0Dependents()
    {
        var result = LoanEvaluator.GetLoanEligibility(4000, false, 650, 0, false);
        Assert.Equal("Review Manually", result);
    }
}
