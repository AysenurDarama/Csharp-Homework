using AutoMapper;
using Business.Dtos.Requests.Bootcamp;
using Business.Dtos.Responses.Bootcamp;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.Profiles;

public class BootcampMappingProfile : Profile
{
    public BootcampMappingProfile()
    {
        CreateMap<CreateBootcampRequest, Bootcamp>();
        CreateMap<UpdateBootcampRequest, Bootcamp>();

        CreateMap<Bootcamp, CreatedBootcampResponse>();
        CreateMap<Bootcamp, UpdatedBootcampResponse>();
        CreateMap<Bootcamp, DeletedBootcampResponse>();
        CreateMap<Bootcamp, GetBootcampResponse>();
    }
}
