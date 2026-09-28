namespace SrpLab;

public class GradeCsvExporter
{
    public string Export(
        Dictionary<string, List<decimal>> scores,
        Func<string, decimal> average,
        Func<string, string> letter,
        Func<string, bool> honorRoll)
    {
        var rows = new List<string>
        {
            "studentId,average,letter,honor"
        };

        foreach (var id in scores.Keys.OrderBy(x => x))
        {
            rows.Add(
                $"{id},{average(id)},{letter(id)},{(honorRoll(id) ? 1 : 0)}");
        }

        return string.Join('\n', rows);
    }
}