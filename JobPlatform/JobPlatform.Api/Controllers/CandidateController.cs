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
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository candidateRepository;
        private readonly IMapper mapper;

        public CandidateController(ICandidateRepository candidateRepository, IMapper mapper)
        {
            this.candidateRepository = candidateRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var candidate = await candidateRepository.GetByIdAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CandidateDto>(candidate));
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCandidateRequestDto updateCandidateRequestDto)
        {
            var candidateDomainModel = mapper.Map<Candidate>(updateCandidateRequestDto);
            candidateDomainModel = await candidateRepository.UpdateAsync(id, candidateDomainModel);
            if (candidateDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CandidateDto>(candidateDomainModel));
        }
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var candidate = await candidateRepository.DeleteAsync(id);
            if ( candidate == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CandidateDto>(candidate));
        }
            
    }
}
