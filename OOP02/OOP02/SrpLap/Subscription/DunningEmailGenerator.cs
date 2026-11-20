namespace SrpLab;

public class DunningEmailGenerator
{
    public string Generate(
        string customerName,
        DateOnly asOf,
        decimal amount,
        string invoice,
        int failedPayments)
    {
        var severity = failedPayments switch
        {
            <= 1 => "friendly reminder",
            2 => "second notice",
            _ => "final notice before suspension"
        };

        return $"Subject: {severity} {invoice}\n" +
               $"Hi {customerName},\n" +
               $"Balance {amount:C} as of {asOf:o} " +
               $"({failedPayments} failures).\n";
    }
}