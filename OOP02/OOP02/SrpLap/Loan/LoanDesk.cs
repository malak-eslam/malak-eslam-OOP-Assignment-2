namespace SrpLab;

public sealed class LoanDesk
{
    private readonly RiskCalculator _riskCalculator = new();
    private readonly RequiredDocumentsService _documentsService = new();
    private readonly DecisionLetterGenerator _decisionLetterGenerator = new();
    private readonly UnderwriterCsvExporter _csvExporter = new();

    public decimal RequestedAmount { get; }
    public int CreditScore { get; }
    public int EmploymentMonths { get; }
    public bool HasCollateral { get; }

    public LoanDesk(decimal requestedAmount,int creditScore,int employmentMonths,bool hasCollateral)
    {
        RequestedAmount = requestedAmount;
        CreditScore = creditScore;
        EmploymentMonths = employmentMonths;
        HasCollateral = hasCollateral;
    }

    public decimal RiskScore()
    {
        return _riskCalculator.Calculate(
            RequestedAmount,
            CreditScore,
            EmploymentMonths,
            HasCollateral);
    }

    public bool IsEligible()
    {
        return _riskCalculator.IsEligible(RiskScore(),CreditScore);
    }

    public IReadOnlyList<string> RequiredDocuments()
    {
        return _documentsService.GetRequiredDocuments(RequestedAmount, EmploymentMonths,HasCollateral,IsEligible());
    }

    public string DecisionLetter(string applicantName)
    {
        return _decisionLetterGenerator.Generate(applicantName,RequestedAmount,RiskScore(),IsEligible(),RequiredDocuments());
    }

    public string UnderwriterCsvRow(string applicationId)
    {
        return _csvExporter.Export(applicationId,CreditScore,EmploymentMonths,HasCollateral,RiskScore(),IsEligible());
    }
}