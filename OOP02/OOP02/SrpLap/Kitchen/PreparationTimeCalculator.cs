namespace SrpLab;

public class PreparationTimeCalculator
{
    public int Calculate(
        IEnumerable<(string Item, List<string> Ingredients, int PrepMinutes)> items,
        int openStations,
        IReadOnlyList<string> allergens)
    {
        if (openStations <= 0)
            openStations = 1;

        var itemList = items.ToList();

        var sequential = itemList.Sum(i => i.PrepMinutes);

        var parallel =
            (int)Math.Ceiling(sequential / (double)openStations);

        if (allergens.Count > 0)
            parallel += 3;

        var longest = itemList.Count == 0
            ? 0
            : itemList.Max(i => i.PrepMinutes);

        return Math.Max(parallel, longest);
    }
}