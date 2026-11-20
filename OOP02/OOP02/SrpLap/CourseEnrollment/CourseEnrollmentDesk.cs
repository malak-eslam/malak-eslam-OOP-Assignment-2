namespace SrpLab;

public sealed class CourseEnrollmentDesk
{
    private readonly HashSet<string> _seated =
        new(StringComparer.OrdinalIgnoreCase);

    private readonly List<string> _waitlist = new();

    private readonly EnrollmentService _enrollmentService = new();
    private readonly WelcomePacketGenerator _welcomePacketGenerator = new();
    private readonly TuitionInvoiceGenerator _tuitionInvoiceGenerator = new();

    public int Capacity { get; }
    public decimal Tuition { get; }
    public string CourseCode { get; }

    public CourseEnrollmentDesk(
        string courseCode,
        int capacity,
        decimal tuition)
    {
        CourseCode = courseCode;
        Capacity = capacity;
        Tuition = tuition;
    }

    public string Register(string studentEmail)
    {
        return _enrollmentService.Register(
            _seated,
            _waitlist,
            Capacity,
            studentEmail);
    }

    public int WaitlistPosition(string studentEmail)
    {
        return _enrollmentService.WaitlistPosition(
            _waitlist,
            studentEmail);
    }

    public string WelcomePacketMarkdown(
        string studentEmail,
        string studentName)
    {
        var isSeated = _seated.Contains(studentEmail);

        return _welcomePacketGenerator.Generate(
            CourseCode,
            isSeated,
            WaitlistPosition(studentEmail),
            studentName);
    }

    public string TuitionInvoiceLine(string studentEmail)
    {
        var isSeated = _seated.Contains(studentEmail);

        return _tuitionInvoiceGenerator.Generate(
            CourseCode,
            Tuition,
            isSeated,
            studentEmail);
    }

    public void PromoteFromWaitlist(int seats)
    {
        _enrollmentService.PromoteFromWaitlist(
            _seated,
            _waitlist,
            Capacity,
            seats);
    }
}