using Core.BusinessException;
using Repositories.Abstract;

namespace Business.Rules;

public class BlacklistBusinessRules
{
    private readonly IBlacklistRepository _blacklistRepository;

    public BlacklistBusinessRules(IBlacklistRepository blacklistRepository)
    {
        _blacklistRepository = blacklistRepository;
    }

    public async Task CheckIfApplicantHasActiveBlacklist(int applicantId)
    {
        var existing = await _blacklistRepository.GetAsync(b => b.ApplicantId == applicantId);
        if (existing != null)
            throw new BusinessException("Bu öğrenci zaten kara listededir.");
    }

    public async Task EnsureReasonIsNotEmpty(string reason)
    {
        if (string.IsNullOrWhiteSpace(reason))
            throw new BusinessException("Sebep boş bırakılamaz.");
    }
}

