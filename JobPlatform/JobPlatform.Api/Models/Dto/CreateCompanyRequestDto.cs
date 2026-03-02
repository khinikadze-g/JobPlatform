using JobPlatform.Api.Models.Domain;

namespace JobPlatform.Api.Models.Dto
{
    public class CreateCompanyRequestDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string PhoneNumber { get; set; }
    }
}
