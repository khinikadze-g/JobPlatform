using JobPlatform.Api.Models.Domain;

namespace JobPlatform.Api.Repositories
{
    public interface IJobRepository
    {
        Task<List<Job>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? 
            sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 20);
        Task<Job?> GetByIdAsync(int id);
        Task<Job> CreateAsync(Job job);
    }
}
