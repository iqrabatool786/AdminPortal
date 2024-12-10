namespace WebApplication1.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; } 
        public string CompanyName { get; set; }
        public string ServiceRequired { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Status { get; set; } 
        public byte[]? Document { get; set; }

        public virtual Employee Employee { get; set; }  // Navigation property
    }


}
