using System;

namespace ProjectManager
{
    public class Project
    {
        public string Name { get; set; }
        public string Status { get; set; }
    }

    public class TaskItem
    {
        public string Title { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime Deadline { get; set; }
    }
}