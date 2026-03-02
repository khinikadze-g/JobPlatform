using JobPlatform.Api.Data;
using JobPlatform.Api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace JobPlatform.Api.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly JobPlatformDbContext dbContext;

        public CompanyRepository(JobPlatformDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Company> CreateAsync(Company company)
        {
            await dbContext.Companys.AddAsync(company);
            await dbContext.SaveChangesAsync();
            return company;
        }

        public async Task<Company?> DeleteAsync(int id)
        {
            var existing = await dbContext.Companys.FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null)
            { 
                return null;
            }
            dbContext.Remove(existing);
            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await dbContext.Companys.Include("jobs").ToListAsync();
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            return await dbContext.Companys.Include("jobs").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Company?> UpdateAsync(int id, Company company)
        {
            var existing = await dbContext.Companys.FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null)
            {
                return null;
            }
            existing.Name = company.Name;
            existing.Description = company.Description;
            existing.PhoneNumber = company.PhoneNumber;
            await dbContext.SaveChangesAsync();
            return existing;
        }
    }
}
