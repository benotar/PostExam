﻿using System.Text.Json.Serialization;

namespace Exam.Entities;

public class Feedback : BaseEntity
{
    public string Title { get; set; }
    public string Text { get; set; }
    public int Rating { get; set; }
    public int UserId { get; set; }
    
    [JsonIgnore]
    public User User { get; set; }
    public int PostId { get; set; }
    
    [JsonIgnore]
    public Post Post { get; set; }
}