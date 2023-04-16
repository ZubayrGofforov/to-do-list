namespace ToDoListApp.Models
{
    public class Task
    {
        public long Id { get; set; }

        public string Title { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public DateTime BeginTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Status { get; set; } = String.Empty;

        public long OwnerId { get; set; }
    }
}
