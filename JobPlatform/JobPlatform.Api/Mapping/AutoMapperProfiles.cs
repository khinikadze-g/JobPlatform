using AutoMapper;
using JobPlatform.Api.Models.Domain;
using JobPlatform.Api.Models.Dto;

namespace JobPlatform.Api.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Candidate, CandidateDto>().ReverseMap();
            CreateMap<Candidate, UpdateCandidateRequestDto>().ReverseMap();
            CreateMap<Job, JobDto>().ReverseMap();
            CreateMap<Job, CreateJobRequestDto>().ReverseMap();
            CreateMap<Job, JobForCompanyDto>().ReverseMap();
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Company, CreateCompanyRequestDto>().ReverseMap();
            CreateMap<Company, UpdateCompanyRequestDto>().ReverseMap();
            CreateMap<Company, CompanyDtoForJobs>().ReverseMap();
            CreateMap<CreateApplicationRequestDto, JobApplication>();
            CreateMap<JobApplication, CandidateApplicationDto>().ReverseMap();
        }
    }

}
