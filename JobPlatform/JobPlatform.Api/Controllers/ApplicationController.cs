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
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationRepository applicationRepository;
        private readonly IMapper mapper;

        public ApplicationController(IApplicationRepository applicationRepository, IMapper mapper)
        {
            this.applicationRepository = applicationRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Apply([FromBody] CreateApplicationRequestDto createApplicationRequestDto)
        {
            var apply = mapper.Map<JobApplication>(createApplicationRequestDto);
            await applicationRepository.ApplyAsync(apply);
            return Ok(apply);
        }
        [HttpGet("Candidate/{candidateId}")]
        [Authorize]
        public async Task<IActionResult> GetByCandidate(int candidateId)
        {
            var applications = await applicationRepository.GetByCandidateAsync(candidateId);

            if (applications == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<List<CandidateApplicationDto>>(applications));
        }
    }
}
