namespace ESFJobBoard.API.Model
{
    public class Job : BaseEntity
    {
        public int EmployerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DatePosted { get; set; }
    }
}