using AutoMapper;
using Business.Dtos.Requests.Instructor;
using Business.Dtos.Responses.Instructor;
using Entities;

namespace Business.Mapping.Profiles;

public class InstructorMappingProfile : Profile
{
    public InstructorMappingProfile()
    {
        CreateMap<CreateInstructorRequest, Instructor>();
        CreateMap<UpdateInstructorRequest, Instructor>();

        CreateMap<Instructor, CreatedInstructorResponse>();
        CreateMap<Instructor, UpdatedInstructorResponse>();
        CreateMap<Instructor, DeletedInstructorResponse>();
        CreateMap<Instructor, GetInstructorResponse>();
    }
}