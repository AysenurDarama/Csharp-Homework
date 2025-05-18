using AutoMapper;
using Business.Dtos.Requests.Applicant;
using Business.Dtos.Responses.Applicant;
using Entities;

namespace Business.Mapping.Profiles;

public class ApplicantMappingProfile : Profile
{
    public ApplicantMappingProfile()
    {
        CreateMap<CreateApplicantRequest, Applicant>();
        CreateMap<UpdateApplicantRequest, Applicant>();

        CreateMap<Applicant, CreatedApplicantResponse>();
        CreateMap<Applicant, UpdatedApplicantResponse>();
        CreateMap<Applicant, DeletedApplicantResponse>();
        CreateMap<Applicant, GetApplicantResponse>();
    }
}