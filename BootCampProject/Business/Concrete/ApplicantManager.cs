using AutoMapper;
using Business.Abstract;
using Business.Dtos.Requests.Applicant;
using Business.Dtos.Responses.Applicant;
using Business.Rules;
using Core.Exceptions;
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
    private readonly IMapper _mapper;
    private readonly ApplicantBusinessRules _applicantBusinessRules;

    public ApplicantManager(
        IApplicantRepository applicantRepository,
        IMapper mapper,
        ApplicantBusinessRules applicantBusinessRules)
    {
        _applicantRepository = applicantRepository;
        _mapper = mapper;
        _applicantBusinessRules = applicantBusinessRules;
    }

    public async Task<List<GetApplicantResponse>> GetAllAsync()
    {
        var applicants = await _applicantRepository.GetAllAsync();
        return _mapper.Map<List<GetApplicantResponse>>(applicants);
    }

    public async Task<GetApplicantResponse> GetByIdAsync(int id)
    {
        var applicant = await _applicantRepository.GetByIdAsync(id);
        if (applicant == null)
            throw new NotFoundException($"Id'si {id} olan başvuru sahibi bulunamadı.");

        return _mapper.Map<GetApplicantResponse>(applicant);
    }

    public async Task<CreatedApplicantResponse> AddAsync(CreateApplicantRequest request)
    {
        await _applicantBusinessRules.ApplicantNationalIdCannotBeDuplicated(request.NationalIdentity);
        await _applicantBusinessRules.ApplicantCannotBeInBlacklistByNationalId(request.NationalIdentity);

        var applicant = _mapper.Map<Applicant>(request);
        var created = await _applicantRepository.AddAsync(applicant);
        return _mapper.Map<CreatedApplicantResponse>(created);
    }

    public async Task<UpdatedApplicantResponse> UpdateAsync(UpdateApplicantRequest request)
    {
        await _applicantBusinessRules.CheckIfApplicantExists(request.Id);

        var applicant = _mapper.Map<Applicant>(request);
        var updated = await _applicantRepository.UpdateAsync(applicant);
        return _mapper.Map<UpdatedApplicantResponse>(updated);
    }

    public async Task<DeletedApplicantResponse> DeleteAsync(int id)
    {
        await _applicantBusinessRules.CheckIfApplicantExists(id);

        var applicant = await _applicantRepository.GetByIdAsync(id);
        var deleted = await _applicantRepository.DeleteAsync(applicant);
        return _mapper.Map<DeletedApplicantResponse>(deleted);
    }
}



