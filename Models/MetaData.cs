namespace TrivyDash.Models
{
    public class MetaData
    {
        public OS OS { get; set; }
        public string ImageID { get; set; }
        public List<string> DiffIDs { get; set; }
        public List<string> RepoTags { get; set; }
        public List<string> RepoDigests { get; set; }
        public ImageConfig ImageConfig { get; set; }
    }
}
