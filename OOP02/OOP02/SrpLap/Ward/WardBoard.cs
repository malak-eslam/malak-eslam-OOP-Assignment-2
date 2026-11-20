namespace SrpLab
{
    public sealed class WardBoard
    {
        private readonly Dictionary<int, string> _bedPatient = new();
        private readonly Dictionary<int, int> _vitalsScore = new();

        private readonly AcuityCalculator _acuityCalculator = new();
        private readonly PagerAlertService _pagerAlertService = new();
        private readonly HandoffNoteGenerator _handoffNoteGenerator = new();
        private readonly CensusCsvExporter _censusCsvExporter = new();

        public void AssignBed(int bed, string patientId, int heartRate, int spo2)
        {
            if (bed <= 0)
                throw new ArgumentOutOfRangeException(nameof(bed));

            if (string.IsNullOrWhiteSpace(patientId))
                throw new ArgumentException("patient required");

            _bedPatient[bed] = patientId.Trim().ToUpperInvariant();

            var acuity = _acuityCalculator.ScoreAcuity(heartRate, spo2);
            _vitalsScore[bed] = acuity;

            _pagerAlertService.AddAlert(bed, acuity);
        }

        public string BuildHandoffNote(int bed)
        {
            if (!_bedPatient.TryGetValue(bed, out var patient))
                return $"Bed {bed}: empty";

            var acuity = _vitalsScore[bed];

            return _handoffNoteGenerator.Build(
                bed,
                patient,
                acuity);
        }

        public IReadOnlyList<string> DrainPagerLog()
        {
            return _pagerAlertService.DrainLog();
        }

        public string ExportCensusCsv()
        {
            return _censusCsvExporter.Export(
                _bedPatient,
                _vitalsScore);
        }
    }
}

