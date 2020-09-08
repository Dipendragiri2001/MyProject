using System;

namespace MyProject.ViewModel
{
    public class TaskIndexView
    {
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TaskId { get; set; }
        public string UserId { get; set; }
    }
}