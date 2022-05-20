using TrivyDash.Models;

namespace TrivyDash.Dtos
{
    public class ReportReadDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int SchemaVersion { get; set; }
        public string? ArtifactName { get; set; }
        public string? ArtifactType { get; set; }
        public MetaData? MetaData { get; set; }
        public List<Result>? Results { get; set; }
    }
}
