using JobPlatform.Api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace JobPlatform.Api.Repositories
{
    public interface ICandidateRepository 
    {
        Task<Candidate?> GetByIdAsync(int id);
        Task<Candidate?> UpdateAsync(int id, Candidate candidate);
        Task<Candidate?> DeleteAsync(int id);
    }
}
