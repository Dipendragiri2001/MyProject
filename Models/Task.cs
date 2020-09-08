using System;

namespace MyProject.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime CompletedAt { get; set; }
        public bool Status { get; set; }
        public bool isAssigned { get; set; }
        public bool isCompleted{get; set;}
    }
}