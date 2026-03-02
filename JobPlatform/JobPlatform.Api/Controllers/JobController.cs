using AutoMapper;
using JobPlatform.Api.Models.Domain;
using JobPlatform.Api.Models.Dto;
using JobPlatform.Api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository jobRepository;
        private readonly IMapper mapper;

        public JobController(IJobRepository jobRepository, IMapper mapper)
        {
            this.jobRepository = jobRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var jobs = await jobRepository.GetAllAsync();
            return Ok(mapper.Map<List<JobDto>>(jobs));
        }
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var job = await jobRepository.GetByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<JobDto>(job));
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateJobRequestDto createJobRequestDto)
        {
            var jobDomainModel = mapper.Map<Job>(createJobRequestDto);
            await jobRepository.CreateAsync(jobDomainModel);

            return Ok(mapper.Map<JobDto>(jobDomainModel));
        }
    }
}
