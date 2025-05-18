using Core.BusinessException;
using Entities;
using Repositories.Abstract;

namespace Business.Rules;

public class ApplicationBusinessRules
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IBlacklistRepository _blacklistRepository;

    public ApplicationBusinessRules(IApplicationRepository applicationRepository, IBootcampRepository bootcampRepository, IBlacklistRepository blacklistRepository)
    {
        _applicationRepository = applicationRepository;
        _bootcampRepository = bootcampRepository;
        _blacklistRepository = blacklistRepository;
    }

    public async Task CheckDuplicateApplication(int applicantId, int bootcampId)
    {
        var existing = await _applicationRepository.GetAsync(a => a.ApplicantId == applicantId && a.BootcampId == bootcampId);
        if (existing != null)
            throw new BusinessException("Aynı bootcamp'e birden fazla başvuru yapılamaz.");
    }

    public async Task CheckIfBootcampIsActive(int bootcampId)
    {
        var bootcamp = await _bootcampRepository.GetAsync(b => b.Id == bootcampId);
        if (bootcamp == null || bootcamp.BootcampState == BootcampState.CANCELLED)
            throw new BusinessException("Aktif olmayan bir bootcamp'e başvuru yapılamaz.");
    }

    public async Task CheckIfBlacklisted(int applicantId)
    {
        var blacklist = await _blacklistRepository.GetAsync(b => b.ApplicantId == applicantId);
        if (blacklist != null)
            throw new BusinessException("Kara listede olan kullanıcı başvuru yapamaz.");
    }

    public void CheckStatusTransition(ApplicationState current, ApplicationState next)
    {
        var validTransitions = new Dictionary<ApplicationState, List<ApplicationState>>()
        {
            { ApplicationState.PENDING, new List<ApplicationState>{ ApplicationState.APPROVED, ApplicationState.REJECTED, ApplicationState.IN_REVIEW } },
            { ApplicationState.IN_REVIEW, new List<ApplicationState>{ ApplicationState.APPROVED, ApplicationState.REJECTED } },
            { ApplicationState.APPROVED, new List<ApplicationState>{ ApplicationState.CANCELLED } },
            
        };

        if (!validTransitions.ContainsKey(current) || !validTransitions[current].Contains(next))
            throw new BusinessException($"Geçersiz başvuru durumu geçişi: {current} → {next}");
    }
}
