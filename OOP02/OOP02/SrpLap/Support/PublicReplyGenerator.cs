namespace SrpLab;

public sealed class PublicReplyGenerator
{
    public string Generate(
        string ticketId,
        string priority,
        string agentName,
        DateTimeOffset slaDeadline)
    {
        var apology = priority == "P1"
            ? "We are treating this as a critical incident."
            : "Thanks for reaching out.";

        return $"Hi,\n{apology}\nTicket {ticketId} is with {agentName}. Next update before {slaDeadline:u}.\n";
    }
}