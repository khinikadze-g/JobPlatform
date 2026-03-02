using JobPlatform.Api.Models.Domain;

namespace JobPlatform.Api.Models.Dto
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string PhoneNumber { get; set; }
        public List<JobForCompanyDto> jobs { get; set; }
    }
}
