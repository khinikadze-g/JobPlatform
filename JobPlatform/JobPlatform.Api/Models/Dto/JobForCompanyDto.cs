namespace JobPlatform.Api.Models.Dto
{
    public class JobForCompanyDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Salary { get; set; }
        public string Location { get; set; }
        public string RequiredQualification { get; set; }
    }
}
