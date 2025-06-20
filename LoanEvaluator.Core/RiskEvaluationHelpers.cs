namespace LoanApp.Core;

public static class RiskEvaluationHelpers
{
    public static string EvaluateEmployed(int creditScore, int dependents, bool ownsHouse)
    {
        if (creditScore >= 700)
        {
            if (dependents == 0) return "Eligible";
            if (dependents <= 2) return "Review Manually";
            return "Not Eligible";
        }
        if (creditScore >= 600) return (ownsHouse) ? "Review Manually" : "Not Eligible";
        return "Not Eligible";
    }

    public static string EvaluateUnemployed(int creditScore, int income, int dependents, bool ownsHouse)
    {
        if (creditScore >= 750 && income > 5000 && ownsHouse) return "Eligible";
        if (creditScore >= 650 && dependents == 0) return "Review Manually";
        return "Not Eligible";
    }
}
