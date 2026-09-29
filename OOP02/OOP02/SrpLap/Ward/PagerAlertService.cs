using System;

public class PagerAlertService
{
    private readonly List<string> _pagerLog = new();

    public void AddAlert(int bed, int acuity)
    {
        if (acuity >= 8)
            _pagerLog.Add($"CODE-YELLOW bed={bed} at {DateTime.UtcNow:HH:mm}");
    }

    public IReadOnlyList<string> DrainLog()
    {
        var copy = _pagerLog.ToList();
        _pagerLog.Clear();
        return copy;
    }
}
