using JobPlatform.Api.Data;
using JobPlatform.Api.Models.Domain;
using JobPlatform.Api.Models.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<JobApplication> ApplyAsync(JobApplication application)
        {
            var existingCandidate = await dbContext.Candidates.FirstOrDefaultAsync(x => x.Id == application.CandidateId);
            if (existingCandidate == null)
            {
                Console.WriteLine("Candidate not found");
                return null;
            }
            var existingJob = await dbContext.Jobs.FirstOrDefaultAsync(x => x.Id == application.JobId);
            if (existingJob == null)
            {
                Console.WriteLine("Job not found");
                return null;
            }
            var candidateQualification = await dbContext.Candidates.FirstOrDefaultAsync(x => x.Id == application.CandidateId);
            if (candidateQualification.Qualification != existingJob.RequiredQualification)
            {
                Console.WriteLine("Qualification does not match");
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
                Salary = a.Job.Salary,
               
            })
            .ToListAsync();
        }
    }
}
