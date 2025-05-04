using AutoMapper;
using Business.Dtos.Requests.Application;
using Business.Dtos.Responses.Application;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Mapping.Profiles;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<CreateApplicationRequest, Application>();
        CreateMap<UpdateApplicationRequest, Application>();

        CreateMap<Application, CreatedApplicationResponse>();
        CreateMap<Application, UpdatedApplicationResponse>();
        CreateMap<Application, DeletedApplicationResponse>();
        CreateMap<Application, GetApplicationResponse>();
    }
}
