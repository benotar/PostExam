namespace Exam.Entities.DTOs;

public class FeedbackDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public int Rating { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
}