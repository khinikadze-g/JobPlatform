
namespace JobPlatform.Api.Models.Domain
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string Qualification { get; set; }
        public int ExperienceYears { get; set; }
        public List<JobApplication> JobApplications { get; set; } = new List<JobApplication>();

    }
}
