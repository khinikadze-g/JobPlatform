using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobPlatform.Api.Data
{
    public class JobPlatformAuthDbContext : IdentityDbContext
    {
        public JobPlatformAuthDbContext(DbContextOptions<JobPlatformAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var candidateRoleId = "13998812-1b92-4695-978e-ca4f18c679ee";
            var adminRoleId = "97269d64-32c5-4668-84db-909a69a73d04";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = candidateRoleId,
                    ConcurrencyStamp = candidateRoleId,
                    Name = "Candidate",
                    NormalizedName = "Candidate"
                },
                new IdentityRole
                {
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin"
                }

            };
            builder.Entity<IdentityRole>().HasData(roles);

        }
    }
}
