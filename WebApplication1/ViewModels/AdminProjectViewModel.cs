namespace WebApplication1.ViewModels
{
    public class AdminProjectViewModel
    {
        public int ProjectId { get; set; }
        public string CompanyName { get; set; }
        public string ServiceRequired { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Status { get; set; }
        public string EmployeeName { get; set; }
    }

}
