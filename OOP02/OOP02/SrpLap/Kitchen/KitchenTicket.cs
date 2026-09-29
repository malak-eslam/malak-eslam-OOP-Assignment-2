namespace SrpLab;

public sealed class KitchenTicket
{
    private readonly List<(string Item, List<string> Ingredients, int PrepMinutes)> _items = new();

    private readonly AllergenDetector _allergenDetector = new();
    private readonly PreparationTimeCalculator _preparationCalculator = new();
    private readonly ThermalTicketRenderer _thermalRenderer = new();
    private readonly ExpoLaneRouter _expoLaneRouter = new();

    public void AddItem(
        string item,
        IEnumerable<string> ingredients,
        int prepMinutes)
    {
        _items.Add((
            item,
            ingredients
                .Select(i => i.Trim().ToLowerInvariant())
                .ToList(),
            prepMinutes));
    }

    public IReadOnlyList<string> DetectAllergens()
    {
        return _allergenDetector.Detect(_items);
    }

    public int EstimatedReadyMinutes(int openStations)
    {
        return _preparationCalculator.Calculate(
            _items,
            openStations,
            DetectAllergens());
    }

    public string RenderThermalTicket(int orderNumber)
    {
        return _thermalRenderer.Render(
            orderNumber,
            _items,
            EstimatedReadyMinutes(2),
            DetectAllergens());
    }

    public string ExpoLaneHint()
    {
        return _expoLaneRouter.GetLane(
            DetectAllergens(),
            EstimatedReadyMinutes(2));
    }
}