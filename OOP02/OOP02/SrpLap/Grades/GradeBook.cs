namespace SrpLab;

public sealed class GradeBook
{
    private readonly Dictionary<string, List<decimal>> _scores =
        new(StringComparer.OrdinalIgnoreCase);

    private readonly GradingPolicy _gradingPolicy = new();
    private readonly HonorRollPolicy _honorRollPolicy = new();
    private readonly TranscriptGenerator _transcriptGenerator = new();
    private readonly GradeCsvExporter _csvExporter = new();

    public void Record(string studentId, decimal score)
    {
        if (score is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(score));

        if (!_scores.TryGetValue(studentId, out var list))
        {
            list = new List<decimal>();
            _scores[studentId] = list;
        }

        list.Add(score);
    }

    public decimal Average(string studentId)
    {
        if (!_scores.TryGetValue(studentId, out var list) ||
            list.Count == 0)
            return 0m;

        return Math.Round(list.Average(), 2);
    }

    public string Letter(string studentId)
    {
        return _gradingPolicy.GetLetter(Average(studentId));
    }

    public bool MeetsHonorRoll(string studentId)
    {
        return _honorRollPolicy.Meets(
            Average(studentId),
            Letter(studentId));
    }

    public string TranscriptPlain(
        string studentId,
        string fullName)
    {
        return _transcriptGenerator.Generate(
            studentId,
            fullName,
            Average(studentId),
            Letter(studentId),
            MeetsHonorRoll(studentId));
    }

    public string ExportCsv()
    {
        return _csvExporter.Export(
            _scores,
            Average,
            Letter,
            MeetsHonorRoll);
    }
}