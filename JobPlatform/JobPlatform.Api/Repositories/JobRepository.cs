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

        public async Task<List<Job>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 20)
        {
            var jobs = dbContext.Jobs.Include("Company").AsQueryable();
            if (filterOn != null && filterQuery != null)
            {
                if (filterOn.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    jobs = jobs.Where(x => x.Title.Contains(filterQuery.ToLower()));
                }
            }
            if (sortBy != null)
            {
                if (sortBy.Equals("Salary", StringComparison.OrdinalIgnoreCase))
                {
                    jobs = isAscending ? jobs.OrderBy(x => x.Salary) : jobs.OrderByDescending(x => x.Salary);
                }
            }
            var skipResult = (pageNumber - 1) * pageSize;
            return await jobs.Skip(skipResult).Take(pageSize).ToListAsync();
            //return await dbContext.Jobs.Include("Company").ToListAsync();
        }

        public async Task<Job?> GetByIdAsync(int id)
        {
            return await dbContext.Jobs.Include("Company").FirstOrDefaultAsync(x  => x.Id == id);
        }
    }
}
