namespace SrpLab;

public class PickingRouteCalculator
{
    public IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> Calculate(
        IEnumerable<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> lines)
    {
        return lines
            .OrderBy(l => l.Aisle)
            .ThenBy(l => l.Bin)
            .Select(l => (
                l.Aisle,
                l.Bin,
                l.Sku,
                Qty: Math.Min(l.QtyNeeded, l.QtyOnHand)))
            .Where(x => x.Qty > 0)
            .ToList();
    }
}