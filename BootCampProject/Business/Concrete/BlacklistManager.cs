using AutoMapper;
using Business.Abstract;
using Business.Dtos.Requests.Blacklist;
using Business.Dtos.Responses.Blacklist;
using Business.Rules;
using Core.BusinessException;
using Entities;
using Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class BlacklistManager : IBlacklistService
{
    private readonly IBlacklistRepository _blacklistRepository;
    private readonly IMapper _mapper;
    private readonly BlacklistBusinessRules _blacklistBusinessRules;

    public BlacklistManager(
        IBlacklistRepository blacklistRepository,
        IMapper mapper,
        BlacklistBusinessRules blacklistBusinessRules)
    {
        _blacklistRepository = blacklistRepository;
        _mapper = mapper;
        _blacklistBusinessRules = blacklistBusinessRules;
    }

    public async Task<CreatedBlacklistResponse> AddAsync(CreateBlacklistRequest request)
    {
        await _blacklistBusinessRules.EnsureReasonIsNotEmpty(request.Reason);
        await _blacklistBusinessRules.CheckIfApplicantHasActiveBlacklist(request.ApplicantId);

        var blacklist = _mapper.Map<Blacklist>(request);
        blacklist.Date = DateTime.UtcNow;

        var created = await _blacklistRepository.AddAsync(blacklist);
        return _mapper.Map<CreatedBlacklistResponse>(created);
    }

    public async Task<UpdatedBlacklistResponse> UpdateAsync(UpdateBlacklistRequest request)
    {
        var blacklist = await _blacklistRepository.GetAsync(b => b.Id == request.Id);
        if (blacklist == null)
            throw new BusinessException("Güncellenecek kara liste kaydı bulunamadı.");

        await _blacklistBusinessRules.EnsureReasonIsNotEmpty(request.Reason);

        _mapper.Map(request, blacklist);
        var updated = await _blacklistRepository.UpdateAsync(blacklist);
        return _mapper.Map<UpdatedBlacklistResponse>(updated);
    }

    public async Task<DeletedBlacklistResponse> DeleteAsync(int id)
    {
        var blacklist = await _blacklistRepository.GetAsync(b => b.Id == id);
        if (blacklist == null)
            throw new BusinessException("Silinecek kara liste kaydı bulunamadı.");

        await _blacklistRepository.DeleteAsync(blacklist);
        return new DeletedBlacklistResponse { Id = id };
    }

    public async Task<GetBlacklistResponse> GetByIdAsync(int id)
    {
        var blacklist = await _blacklistRepository.GetAsync(b => b.Id == id);
        if (blacklist == null)
            throw new BusinessException("Kayıt bulunamadı.");

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
        return _mapper.Map<IList<GetBlacklistResponse>>(blacklists);
    }
}
