using JobPlatform.Api.Data;
using JobPlatform.Api.Models.Domain;
using JobPlatform.Api.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace JobPlatform.Api.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly JobPlatformDbContext dbContext;

        public ApplicationRepository(JobPlatformDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<JobApplication?> ApplyAsync(JobApplication application)
        {
            var candidate = await dbContext.Candidates.FirstOrDefaultAsync(x => x.Id == application.CandidateId);
            if (candidate == null)
            {
                return null;
            }
            var job = await dbContext.Jobs.FirstOrDefaultAsync(x => x.Id == application.JobId);
            if (job == null)
            {
                return null;
            }
            if (candidate.Qualification != job.RequiredQualification)
            {
                return null;
            }

            var alreadyApplied = await dbContext.JobApplications.AnyAsync(x => 
            x.CandidateId == application.CandidateId && x.JobId == application.JobId);

            if (alreadyApplied)
            {
                return null;
            }

            await dbContext.JobApplications.AddAsync(application);
            await dbContext.SaveChangesAsync();

            return application;
        }

        public async Task<List<CandidateApplicationDto>> GetByCandidateAsync(int candidateId)
        {
            return await dbContext.JobApplications
                .Where(a => a.CandidateId == candidateId)
                .Select(a => new CandidateApplicationDto
                {
                    ApplicationId = a.Id,
                    JobTitle = a.Job.Title,
                    CompanyName = a.Job.Company.Name,
                    Salary = a.Job.Salary
                }).ToListAsync();
        }
    }
}