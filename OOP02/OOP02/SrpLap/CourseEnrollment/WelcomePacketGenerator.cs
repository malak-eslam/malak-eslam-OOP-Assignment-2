namespace SrpLab;

public class WelcomePacketGenerator
{
    public string Generate(string courseCode,bool isSeated,int waitlistPosition,string studentName)
    {
        var status = isSeated
            ? "confirmed seat"
            : $"waitlist #{waitlistPosition}";

        return $"# Welcome to {courseCode}\n" +
               $"Hi {studentName},\n" +
               $"Your status: **{status}**.\n" +
               $"Bring a laptop. Discord onboarding link: " +
               $"https://example.invalid/{courseCode.ToLowerInvariant()}\n";
    }
}