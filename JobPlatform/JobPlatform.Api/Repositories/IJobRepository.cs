using JobPlatform.Api.Models.Domain;

namespace JobPlatform.Api.Repositories
{
    public interface IJobRepository
    {
        Task<List<Job>> GetAllAsync();
        Task<Job?> GetByIdAsync(int id);
        Task<Job> CreateAsync(Job job);
    }
}
