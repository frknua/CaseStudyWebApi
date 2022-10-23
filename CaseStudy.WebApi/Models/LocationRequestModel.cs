namespace CaseStudy.WebApi.Models
{
    public class LocationRequestModel
    {
        public List<Location> locations { get; set; } 
        public Location customerLocation { get; set; }
    }
}
