namespace SrpLab;

public class StockAllocator
{
    public IReadOnlyList<(string Sku, int Allocated)> Allocate(
        IEnumerable<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> lines)
    {
        return lines
            .Select(line => (
                line.Sku,
                Allocated: Math.Min(line.QtyNeeded, line.QtyOnHand)))
            .ToList();
    }
}