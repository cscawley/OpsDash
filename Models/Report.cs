namespace TrivyDash.Models
{
    public class Report
    {
        public int SchemaVersion { get; set; }
        public string ArtifactName { get; set; }
        public string ArtifactType { get; set; }
        public MetaData MetaData { get; set; }
        public List<Result> Results { get; set; }
    }
}
