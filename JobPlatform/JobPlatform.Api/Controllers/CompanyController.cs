using AutoMapper;
using JobPlatform.Api.Models.Domain;
using JobPlatform.Api.Models.Dto;
using JobPlatform.Api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace JobPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;

        public CompanyController(ICompanyRepository companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var company = await companyRepository.GetAllAsync();
            return Ok(mapper.Map<List<CompanyDto>>(company));
        }
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var company = await companyRepository.GetByIdAsync(id);
            if(company == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CompanyDto>(company));
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateCompanyRequestDto createCompanyRequestDto)
        {
            var companyDomainModel = mapper.Map<Company>(createCompanyRequestDto);
            await companyRepository.CreateAsync(companyDomainModel);
            return Ok(mapper.Map<CompanyDto>(companyDomainModel));
        }
        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCompanyRequestDto updateCompanyRequestDto)
        {
            var companyDomainModel = mapper.Map<Company>(updateCompanyRequestDto);
            companyDomainModel = await companyRepository.UpdateAsync(id, companyDomainModel);
            if (companyDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CompanyDto>(companyDomainModel));
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var company = await companyRepository.DeleteAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CompanyDto>(company));
        }
    }
}
