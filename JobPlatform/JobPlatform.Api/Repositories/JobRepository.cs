using JobPlatform.Api.Data;
using JobPlatform.Api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace JobPlatform.Api.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly JobPlatformDbContext dbContext;

        public JobRepository(JobPlatformDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Job> CreateAsync(Job job)
        {
            await dbContext.Jobs.AddAsync(job);
            await dbContext.SaveChangesAsync();
            return job;
        }

        public async Task<List<Job>> GetAllAsync()
        {
            return await dbContext.Jobs.Include("Company").ToListAsync();
        }

        public async Task<Job?> GetByIdAsync(int id)
        {
            return await dbContext.Jobs.Include("Company").FirstOrDefaultAsync(x  => x.Id == id);
        }
    }
}
