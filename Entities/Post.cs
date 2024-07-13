namespace Exam.Entities;

public class Post : BaseEntity
{
    public string Title { get; set; }

    public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
}