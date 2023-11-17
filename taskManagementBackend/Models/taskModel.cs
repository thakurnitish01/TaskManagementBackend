namespace taskManagementBackend.Models
{
    public class taskModel
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string Description { get; set; }
        public string location { get; set; }
        public bool IsActive { get; set; }
        public DateTime Time { get; set; }
            
    }
}
