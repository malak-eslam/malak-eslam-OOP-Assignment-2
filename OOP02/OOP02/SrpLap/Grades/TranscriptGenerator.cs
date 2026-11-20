namespace SrpLab;

public class TranscriptGenerator
{
    public string Generate(
        string studentId,
        string fullName,
        decimal average,
        string letter,
        bool honorRoll)
    {
        return $"TRANSCRIPT\n" +
               $"Student: {fullName} ({studentId})\n" +
               $"Average: {average}\n" +
               $"Letter: {letter}\n" +
               $"Honor: {honorRoll}\n";
    }
}