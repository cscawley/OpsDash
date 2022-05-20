namespace TrivyDash.Models
{
    public class Result
    {
        public string? Target { get; set; }
        public string? Class { get; set; }
        public string? Type { get; set; }
        public List<Vulnerability>? Vulnerabilities { get; set; }
    }
}
