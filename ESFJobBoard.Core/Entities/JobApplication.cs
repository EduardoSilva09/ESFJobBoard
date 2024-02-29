namespace ESFJobBoard.Core.Entities
{
    public class JobApplication : BaseEntity
    {
        public JobApplication()
        {
            ApplicationDate = DateTime.Now;
        }
        public int JobId { get; set; }
        public int JobSeekerId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public Job Job { get; set; }
        public User JobSeeker { get; set; }
    }
}