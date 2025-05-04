using AutoMapper;
using Business.Abstract;
using Business.Dtos.Requests.Blacklist;
using Business.Dtos.Responses.Blacklist;
using Entities;
using Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Business.Concrete;

public class BlacklistManager : IBlacklistService
{
    private readonly IBlacklistRepository _blacklistRepository;
    private readonly IMapper _mapper;

    public BlacklistManager(IBlacklistRepository blacklistRepository, IMapper mapper)
    {
        _blacklistRepository = blacklistRepository;
        _mapper = mapper;
    }

    public async Task<CreatedBlacklistResponse> AddAsync(CreateBlacklistRequest request)
    {
        Blacklist blacklist = _mapper.Map<Blacklist>(request);
        blacklist.Date = DateTime.UtcNow;

        Blacklist created = await _blacklistRepository.AddAsync(blacklist);
        return _mapper.Map<CreatedBlacklistResponse>(created);
    }

    public async Task<UpdatedBlacklistResponse> UpdateAsync(UpdateBlacklistRequest request)
    {
        Blacklist blacklist = await _blacklistRepository.GetAsync(b => b.Id == request.Id);
        _mapper.Map(request, blacklist);

        Blacklist updated = await _blacklistRepository.UpdateAsync(blacklist);
        return _mapper.Map<UpdatedBlacklistResponse>(updated);
    }

    public async Task<DeletedBlacklistResponse> DeleteAsync(int id)
    {
        Blacklist blacklist = await _blacklistRepository.GetAsync(b => b.Id == id);
        await _blacklistRepository.DeleteAsync(blacklist);

        return new DeletedBlacklistResponse { Id = id };
    }

    public async Task<GetBlacklistResponse> GetByIdAsync(int id)
    {
        Blacklist blacklist = await _blacklistRepository.GetAsync(b => b.Id == id);
        return _mapper.Map<GetBlacklistResponse>(blacklist);
    }

    public async Task<List<GetBlacklistResponse>> GetAllAsync()
    {
        var list = await _blacklistRepository.GetAllAsync();
        return _mapper.Map<List<GetBlacklistResponse>>(list);
    }
    public async Task<IList<GetBlacklistResponse>> GetListAsync()
    {
        var blacklists = await _blacklistRepository.GetAllAsync();
        var response = _mapper.Map<IList<GetBlacklistResponse>>(blacklists);
        return response;
    }
}
