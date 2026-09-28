namespace SrpLab;

public class EnrollmentService
{
    public string Register(HashSet<string> seated,List<string> waitlist,int capacity,string studentEmail)
    {
        if (string.IsNullOrWhiteSpace(studentEmail))
            throw new ArgumentException("email");

        var email = studentEmail.Trim();

        if (seated.Contains(email) || waitlist.Contains(email))
            return "ALREADY_REGISTERED";

        if (seated.Count < capacity)
        {
            seated.Add(email);
            return "SEATED";
        }

        waitlist.Add(email);
        return $"WAITLIST:{waitlist.Count}";
    }

    public int WaitlistPosition(List<string> waitlist,string studentEmail)
    {
        var idx = waitlist.FindIndex(
            x => x.Equals(
                studentEmail,
                StringComparison.OrdinalIgnoreCase));

        return idx < 0 ? -1 : idx + 1;
    }

    public void PromoteFromWaitlist(HashSet<string> seated,List<string> waitlist,int capacity,int seats)
    {
        while (seats > 0 &&
            waitlist.Count > 0 &&
               seated.Count < capacity)
        {
            var next = waitlist[0];

            waitlist.RemoveAt(0);
            seated.Add(next);

            seats--;
        }
    }
}