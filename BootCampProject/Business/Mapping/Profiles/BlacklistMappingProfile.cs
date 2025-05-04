using AutoMapper;
using Business.Dtos.Requests.Blacklist;
using Business.Dtos.Responses.Blacklist;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.Profiles;

public class BlacklistMappingProfile : Profile
{
    public BlacklistMappingProfile()
    {
        CreateMap<CreateBlacklistRequest, Blacklist>();
        CreateMap<UpdateBlacklistRequest, Blacklist>();

        CreateMap<Blacklist, CreatedBlacklistResponse>();
        CreateMap<Blacklist, UpdatedBlacklistResponse>();
        CreateMap<Blacklist, DeletedBlacklistResponse>();
        CreateMap<Blacklist, GetBlacklistResponse>();
    }
}
