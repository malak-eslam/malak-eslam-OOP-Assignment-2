namespace SrpLab;

public class ExpoLaneRouter
{
    public string GetLane(
        IReadOnlyList<string> allergens,
        int estimatedMinutes)
    {
        return allergens.Count > 0
            ? "LANE-ALLERGY"
            : estimatedMinutes > 20
                ? "LANE-SLOW"
                : "LANE-FAST";
    }
}