namespace SrpLab;

public class SlotFinder
{
    public DateTimeOffset? FindNext(
        DateTimeOffset from,
        int searchHours,
        TimeOnly open,
        TimeOnly close,
        int slotMinutes,
        HashSet<DateTimeOffset> booked)
    {
        var cursor = Align(from, slotMinutes);
        var end = from.AddHours(searchHours);

        while (cursor < end)
        {
            var withinHours =
                new BusinessHoursService()
                    .IsWithinBusinessHours(
                        cursor,
                        open,
                        close,
                        slotMinutes);

            if (withinHours && !booked.Contains(cursor))
                return cursor;

            cursor = cursor.AddMinutes(slotMinutes);
        }

        return null;
    }

    private DateTimeOffset Align(
        DateTimeOffset from,
        int slotMinutes)
    {
        var minutes = from.Minute -
                      (from.Minute % slotMinutes);

        return new DateTimeOffset(
            from.Year,
            from.Month,
            from.Day,
            from.Hour,
            minutes,
            0,
            from.Offset);
    }
}