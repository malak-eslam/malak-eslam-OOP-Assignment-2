namespace SrpLab;

public sealed class AppointmentDesk
{
    private readonly HashSet<DateTimeOffset> _booked = new();

    private readonly BusinessHoursService _businessHoursService = new();
    private readonly SlotFinder _slotFinder = new();
    private readonly IcsCalendarGenerator _icsGenerator = new();
    private readonly SmsReminderGenerator _smsGenerator = new();

    public TimeOnly Open { get; }
    public TimeOnly Close { get; }
    public int SlotMinutes { get; }

    public AppointmentDesk(
        TimeOnly open,
        TimeOnly close,
        int slotMinutes)
    {
        Open = open;
        Close = close;
        SlotMinutes = slotMinutes;
    }

    public bool IsWithinBusinessHours(DateTimeOffset when)
    {
        return _businessHoursService.IsWithinBusinessHours(
            when,
            Open,
            Close,
            SlotMinutes);
    }

    public DateTimeOffset? FindNextSlot(
        DateTimeOffset from,
        int searchHours)
    {
        return _slotFinder.FindNext(
            from,
            searchHours,
            Open,
            Close,
            SlotMinutes,
            _booked);
    }

    public bool TryBook(DateTimeOffset slot)
    {
        if (!IsWithinBusinessHours(slot) ||
            _booked.Contains(slot))
            return false;

        _booked.Add(slot);
        return true;
    }

    public string ToIcs(
        DateTimeOffset slot,
        string patientName,
        string clinician)
    {
        return _icsGenerator.Generate(
            slot,
            SlotMinutes,
            patientName,
            clinician);
    }

    public string SmsReminder(
        DateTimeOffset slot,
        string clinicPhone)
    {
        return _smsGenerator.Generate(
            slot,
            clinicPhone);
    }
}