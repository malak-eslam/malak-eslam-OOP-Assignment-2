namespace SrpLab;

public sealed class SupportTicket
{
    private readonly PriorityCalculator _priorityCalculator = new();
    private readonly SlaService _slaService = new();
    private readonly PublicReplyGenerator _publicReplyGenerator = new();
    private readonly EscalationMessageGenerator _escalationMessageGenerator = new();

    public string Id { get; }
    public string Subject { get; private set; }
    public string Body { get; private set; }
    public DateTimeOffset OpenedAt { get; }
    public string Priority { get; private set; } = "P3";

    public SupportTicket(
        string id,
        string subject,
        string body,
        DateTimeOffset openedAt)
    {
        Id = id;
        Subject = subject;
        Body = body;
        OpenedAt = openedAt;

        RecalculatePriorityFromText();
    }

    public void AppendCustomerMessage(string text)
    {
        Body += "\n---\n" + text;
        RecalculatePriorityFromText();
    }

    public void RecalculatePriorityFromText()
    {
        Priority = _priorityCalculator.Calculate(Subject, Body);
    }

    public DateTimeOffset SlaDeadline()
    {
        return _slaService.GetDeadline(Priority, OpenedAt);
    }

    public bool IsBreached(DateTimeOffset now)
    {
        return _slaService.IsBreached(now, SlaDeadline());
    }

    public string DraftPublicReply(string agentName)
    {
        return _publicReplyGenerator.Generate(
            Id,
            Priority,
            agentName,
            SlaDeadline());
    }

    public string InternalEscalationBlurb()
    {
        return _escalationMessageGenerator.Generate(
            Id,
            Priority,
            SlaDeadline());
    }
}