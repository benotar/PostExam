namespace Exam.Entities;

public class User : BaseEntity
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
}