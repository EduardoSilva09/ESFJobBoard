namespace ESFJobBoard.Core.Entities
{
    public class Job : BaseEntity
    {
        public Job(int employerId, string title, string description)
        {
            EmployerId = employerId;
            Title = title;
            Description = description;
            DatePosted = DateTime.Now;
        }
        public int EmployerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DatePosted { get; set; }
        // Navigation properties
        public ICollection<JobApplication> Applications { get; set; }
    }
}