namespace TrivyDash.Models
{
    public enum Severity
    {
        UNKNOWN, LOW, MEDIUM, HIGH, CRITICAL
    }
    public class Report
    {
        public string VulnerabilityID { get; set; }
        public string PkgName { get; set; }
        public string InstalledVersion { get; set; }
        public Severity Severity { get; set; }
    }
}
