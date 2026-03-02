using JobPlatform.Api.Models.Domain;

namespace JobPlatform.Api.Repositories
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAllAsync();
        Task<Company?> GetByIdAsync(int id);
        Task<Company> CreateAsync(Company company);
        Task<Company?> UpdateAsync(int id, Company company);
        Task<Company?> DeleteAsync(int id);
    }
}
