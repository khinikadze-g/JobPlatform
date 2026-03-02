using JobPlatform.Api.Models.Dto;

namespace JobPlatform.Api.Models.Domain
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string PhoneNumber { get; set; }
        public  List<Job> jobs { get; set; } = new List<Job>();

    }
}
