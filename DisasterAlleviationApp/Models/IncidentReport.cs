namespace DisasterAlleviationApp.Models
{
    public class IncidentReport
    {
        public int Id { get; set; }
        public string ReporterName { get; set; } = string.Empty;
        public string DisasterType { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
