namespace JobPlatform.Api.Models.Domain
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Salary { get; set; }
        public string Location { get; set; }
        public string RequiredQualification { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public List<JobApplication> jobApplications { get; set; }
    }
}
