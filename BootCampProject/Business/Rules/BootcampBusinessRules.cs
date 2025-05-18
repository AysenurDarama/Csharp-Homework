using Core.BusinessException;
using Entities;
using Repositories.Abstract;

namespace Business.Rules;

public class BootcampBusinessRules
{
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IInstructorRepository _instructorRepository;

    public BootcampBusinessRules(IBootcampRepository bootcampRepository, IInstructorRepository instructorRepository)
    {
        _bootcampRepository = bootcampRepository;
        _instructorRepository = instructorRepository;
    }

    public async Task CheckStartEndDates(DateTime start, DateTime end)
    {
        if (start >= end)
            throw new BusinessException("Başlangıç tarihi, bitiş tarihinden önce olmalıdır.");
    }

    public async Task CheckDuplicateName(string name)
    {
        var existing = await _bootcampRepository.GetAsync(b => b.Name == name);
        if (existing != null)
            throw new BusinessException("Aynı isimde bir bootcamp zaten mevcut.");
    }

    public async Task CheckIfInstructorExists(int instructorId)
    {
        var instructor = await _instructorRepository.GetByIdAsync(instructorId);
        if (instructor == null)
            throw new BusinessException("Eğitmen bulunamadı.");
    }
}


