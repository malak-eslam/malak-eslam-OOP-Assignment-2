using System;

public class GiftWrapPricing
{
    public decimal GetPrice(bool enabled)
    {
        return enabled ? 4.99m : 0m;
    }
}
