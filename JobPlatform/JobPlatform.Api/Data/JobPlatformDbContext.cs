using JobPlatform.Api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace JobPlatform.Api.Data
{
    public class JobPlatformDbContext : DbContext
    {
        public JobPlatformDbContext(DbContextOptions<JobPlatformDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
    }
}
