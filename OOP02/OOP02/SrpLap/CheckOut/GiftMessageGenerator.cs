using System.Collections.Generic;

namespace SrpLab;

public sealed class GiftMessageGenerator
{
    public string Generate(
        string fromName,
        IEnumerable<string> items,
        decimal total)
    {
        var itemNames = string.Join(", ", items);

        return $"Dear friend,\nA gift from {fromName} awaits ({itemNames}).\nTotal surprise value: {total:C}\n";
    }
}