using JobPlatform.Api.Models.Domain;
using JobPlatform.Api.Models.Dto;

namespace JobPlatform.Api.Repositories
{
    public interface IApplicationRepository
    {
        Task<JobApplication> ApplyAsync(JobApplication application);
        Task<List<CandidateApplicationDto>> GetByCandidateAsync(int candidateId);

    }
}
