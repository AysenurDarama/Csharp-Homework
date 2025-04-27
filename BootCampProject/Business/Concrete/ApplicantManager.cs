using Business.Abstract;
using Entities;
using Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class ApplicantManager : IApplicantService
{
    private readonly IApplicantRepository _applicantRepository;

    public ApplicantManager(IApplicantRepository applicantRepository)
    {
        _applicantRepository = applicantRepository;
    }

    public async Task<List<Applicant>> GetAllAsync()
    {
        return (List<Applicant>)await _applicantRepository.GetAllAsync();
    }

    public async Task<Applicant> GetByIdAsync(int id)
    {
        return await _applicantRepository.GetByIdAsync(id);
    }

    public async Task<Applicant> AddAsync(Applicant applicant)
    {
        return await _applicantRepository.AddAsync(applicant);
    }

    public async Task<Applicant> UpdateAsync(Applicant applicant)
    {
        return await _applicantRepository.UpdateAsync(applicant);
    }

    public async Task DeleteAsync(Applicant applicant)
    {
        await _applicantRepository.DeleteAsync(applicant);
    }
}
