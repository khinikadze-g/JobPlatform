using JobPlatform.Api.Models.Domain;

namespace JobPlatform.Api.Models.Dto
{
    public class JobDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Salary { get; set; }
        public string Location { get; set; }
        public string RequiredQualification { get; set; }
        //public int CompanyId { get; set; }
        public CompanyDtoForJobs Company { get; set; }
        
    }
}
