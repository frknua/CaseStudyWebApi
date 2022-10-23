using System.Text.Json.Serialization;

namespace CaseStudy.Core.DTOs
{
    public abstract class BaseDto
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
    }
}
