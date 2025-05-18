using AutoMapper;
using Business.Abstract;
using Business.Dtos.Requests.Bootcamp;
using Business.Dtos.Responses.Bootcamp;
using Business.Rules;
using Core.BusinessException;
using Entities;
using Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class BootcampManager : IBootcampService
{
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IMapper _mapper;
    private readonly BootcampBusinessRules _bootcampBusinessRules;

    public BootcampManager(
        IBootcampRepository bootcampRepository,
        IMapper mapper,
        BootcampBusinessRules bootcampBusinessRules)
    {
        _bootcampRepository = bootcampRepository;
        _mapper = mapper;
        _bootcampBusinessRules = bootcampBusinessRules;
    }

    public async Task<CreatedBootcampResponse> AddAsync(CreateBootcampRequest request)
    {
        await _bootcampBusinessRules.CheckStartEndDates(request.StartDate, request.EndDate);
        await _bootcampBusinessRules.CheckDuplicateName(request.Name);
        await _bootcampBusinessRules.CheckIfInstructorExists(request.InstructorId);

        var bootcamp = _mapper.Map<Bootcamp>(request);
        var added = await _bootcampRepository.AddAsync(bootcamp);
        return _mapper.Map<CreatedBootcampResponse>(added);
    }

    public async Task<UpdatedBootcampResponse> UpdateAsync(UpdateBootcampRequest request)
    {
        var bootcamp = await _bootcampRepository.GetByIdAsync(request.Id);
        if (bootcamp == null)
            throw new BusinessException("Bootcamp bulunamadı.");

        await _bootcampBusinessRules.CheckStartEndDates(request.StartDate, request.EndDate);

        _mapper.Map(request, bootcamp); 
        var updated = await _bootcampRepository.UpdateAsync(bootcamp);
        return _mapper.Map<UpdatedBootcampResponse>(updated);
    }

    public async Task<DeletedBootcampResponse> DeleteAsync(int id)
    {
        var bootcamp = await _bootcampRepository.GetByIdAsync(id);
        if (bootcamp == null)
            throw new BusinessException("Bootcamp bulunamadı.");

        var deleted = await _bootcampRepository.DeleteAsync(bootcamp);
        return new DeletedBootcampResponse { Id = deleted.Id };
    }

    public async Task<GetBootcampResponse> GetByIdAsync(int id)
    {
        var bootcamp = await _bootcampRepository.GetByIdAsync(id);
        if (bootcamp == null)
            throw new BusinessException("Bootcamp bulunamadı.");

        return _mapper.Map<GetBootcampResponse>(bootcamp);
    }

    public async Task<IList<GetBootcampResponse>> GetListAsync()
    {
        var bootcamps = await _bootcampRepository.GetAllAsync();
        return _mapper.Map<IList<GetBootcampResponse>>(bootcamps);
    }
}
