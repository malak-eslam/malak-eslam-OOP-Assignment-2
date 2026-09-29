namespace SrpLab;

public sealed class WarehousePickList
{
    private readonly List<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> _lines = new();

    private readonly StockAllocator _stockAllocator = new();
    private readonly PickingRouteCalculator _routeCalculator = new();
    private readonly PickerInstructionGenerator _instructionGenerator = new();
    private readonly WmsXmlGenerator _wmsGenerator = new();

    public void AddNeed(
        string sku,
        string aisle,
        int bin,
        int qtyNeeded,
        int qtyOnHand)
    {
        _lines.Add((sku, aisle, bin, qtyNeeded, qtyOnHand));
    }

    public IReadOnlyList<(string Sku, int Allocated)> Allocate()
    {
        return _stockAllocator.Allocate(_lines);
    }

    public IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> WalkingOrder()
    {
        return _routeCalculator.Calculate(_lines);
    }

    public string PickerScript()
    {
        return _instructionGenerator.Generate(
            WalkingOrder(),
            Allocate(),
            _lines);
    }

    public string WmsXmlBatch(string batchId)
    {
        return _wmsGenerator.Generate(
            batchId,
            Allocate());
    }
}