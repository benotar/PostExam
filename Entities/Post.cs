using System.Text.Json.Serialization;

namespace Exam.Entities;

public class Post : BaseEntity
{
    public string Title { get; set; }
    
    [JsonIgnore]
    public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
}