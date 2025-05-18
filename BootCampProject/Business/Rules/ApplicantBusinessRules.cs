using Core.BusinessException;
using Repositories.Abstract;

namespace Business.Rules;

public class ApplicantBusinessRules
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly IBlacklistRepository _blacklistRepository;

    public ApplicantBusinessRules(
        IApplicantRepository applicantRepository,
        IBlacklistRepository blacklistRepository)
    {
        _applicantRepository = applicantRepository;
        _blacklistRepository = blacklistRepository;
    }

    public async Task CheckIfApplicantExists(int id)
    {
        var applicant = await _applicantRepository.GetByIdAsync(id);
        if (applicant == null)
            throw new BusinessException("Böyle bir başvuru sahibi bulunamadı.");
    }

    public async Task ApplicantNationalIdCannotBeDuplicated(string nationalId)
    {
        var existing = await _applicantRepository.GetAsync(a => a.NationalIdentity == nationalId);
        if (existing != null)
            throw new BusinessException("Bu TC kimlik numarası zaten kayıtlı.");
    }

    public async Task ApplicantCannotBeInBlacklistByNationalId(string nationalId)
    {
        var applicant = await _applicantRepository.GetAsync(a => a.NationalIdentity == nationalId);
        if (applicant == null) return; 

        var blacklist = await _blacklistRepository.GetAsync(b => b.ApplicantId == applicant.Id);
        if (blacklist != null)
            throw new BusinessException("Bu kullanıcı kara listededir, işlem yapılamaz.");
    }
}