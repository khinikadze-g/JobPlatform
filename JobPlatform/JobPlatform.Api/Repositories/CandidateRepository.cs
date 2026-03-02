using JobPlatform.Api.Data;
using JobPlatform.Api.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace JobPlatform.Api.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly JobPlatformDbContext dbContext;

        public CandidateRepository(JobPlatformDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Candidate?> DeleteAsync(int id)
        {
            var existing = dbContext.Candidates.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                return null;
            }
            dbContext.Remove(existing);
            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<Candidate?> GetByIdAsync(int id)
        {
            return await dbContext.Candidates.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Candidate?> UpdateAsync(int id, Candidate candidate)
        {
            var existing = await dbContext.Candidates.FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null)
            {
                return null;
            }
            existing.FullName = candidate.FullName;
            existing.PhoneNumber = candidate.PhoneNumber;
            existing.Qualification = candidate.Qualification;
            existing.ExperienceYears = candidate.ExperienceYears;
            await dbContext.SaveChangesAsync();
            return existing;
        }

    }
}
