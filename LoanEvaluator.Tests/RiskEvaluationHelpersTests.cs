using Xunit;
using LoanApp.Core;

namespace LoanApp.Tests;

public class RiskEvaluationHelpersTests
{
    [Theory]
    [InlineData(700, 0, false, "Eligible")]
    [InlineData(720, 1, false, "Review Manually")]
    [InlineData(720, 3, false, "Not Eligible")]
    [InlineData(650, 1, true, "Review Manually")]
    [InlineData(580, 1, true, "Not Eligible")]
    public void EvaluateEmployed_Should_Return_Correct_Result(int credit, int dependents, bool ownsHouse, string expectedResult)
    {
        var result = RiskEvaluationHelpers.EvaluateEmployed(credit, dependents, ownsHouse);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(780, 6000, 1, true, "Eligible")]
    [InlineData(660, 4000, 0, false, "Review Manually")]
    [InlineData(640, 3000, 1, false, "Not Eligible")]
    public void EvaluateUnemployed_Should_Return_Correct_Result(int credit, int income, int dependents, bool ownsHouse, string expectedResult)
    {
        var result = RiskEvaluationHelpers.EvaluateUnemployed(credit, income, dependents, ownsHouse);
        Assert.Equal(expectedResult, result);
    }
}
