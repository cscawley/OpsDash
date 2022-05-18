namespace TrivyDash.Models
{
    public class ImageConfig
    {
        public string architecture { get; set; }
        public string container { get; set; }
        public string created { get; set; }
        public string docker_version { get; set; }
        public List<History> history { get; set; }
        public string os { get; set; }
        public Rootfs rootfs { get; set; }
        public  Config config { get; set; }
    }
}
