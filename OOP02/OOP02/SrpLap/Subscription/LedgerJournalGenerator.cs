namespace SrpLab;

public class LedgerJournalGenerator
{
    public string Generate(
        string customerId,
        string invoice,
        decimal amount)
    {
        return $"{customerId},{invoice},{amount:0.00},AR-SUB";
    }
}