using AutoMapper;
using Business.Abstract;
using Business.Dtos.Requests.Application;
using Business.Dtos.Responses.Application;
using Business.Rules;
using Core.BusinessException;
using Entities;
using Repositories.Abstract;

namespace Business.Concrete;
public class ApplicationManager : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IMapper _mapper;
    private readonly ApplicationBusinessRules _applicationBusinessRules;

    public ApplicationManager(
        IApplicationRepository applicationRepository,
        IMapper mapper,
        ApplicationBusinessRules applicationBusinessRules)
    {
        _applicationRepository = applicationRepository;
        _mapper = mapper;
        _applicationBusinessRules = applicationBusinessRules;
    }

    public async Task<CreatedApplicationResponse> AddAsync(CreateApplicationRequest request)
    {
        await _applicationBusinessRules.CheckDuplicateApplication(request.ApplicantId, request.BootcampId);
        await _applicationBusinessRules.CheckIfBootcampIsActive(request.BootcampId);
        await _applicationBusinessRules.CheckIfBlacklisted(request.ApplicantId);

        Application application = _mapper.Map<Application>(request);
        application.ApplicationState = ApplicationState.PENDING;

        Application createdApp = await _applicationRepository.AddAsync(application);
        return _mapper.Map<CreatedApplicationResponse>(createdApp);
    }

    public async Task<UpdatedApplicationResponse> UpdateAsync(UpdateApplicationRequest request)
    {
        Application application = await _applicationRepository.GetByIdAsync(request.Id);
        if (application == null)
            throw new BusinessException("Başvuru bulunamadı.");

        _applicationBusinessRules.CheckStatusTransition(application.ApplicationState, request.ApplicationState);

        // Map sadece güncellenecek alanlar için yapılır
        _mapper.Map(request, application);

        Application updatedApp = await _applicationRepository.UpdateAsync(application);
        return _mapper.Map<UpdatedApplicationResponse>(updatedApp);
    }

    public async Task<DeletedApplicationResponse> DeleteAsync(int id)
    {
        Application application = await _applicationRepository.GetByIdAsync(id);
        if (application == null)
            throw new BusinessException("Silinecek başvuru bulunamadı.");

        await _applicationRepository.DeleteAsync(application);
        return new DeletedApplicationResponse { Id = id };
    }

    public async Task<GetApplicationResponse> GetByIdAsync(int id)
    {
        Application application = await _applicationRepository.GetByIdAsync(id);
        if (application == null)
            throw new BusinessException("Başvuru bulunamadı.");

        return _mapper.Map<GetApplicationResponse>(application);
    }

    public async Task<List<GetApplicationResponse>> GetListAsync()
    {
        var list = await _applicationRepository.GetAllAsync();
        return _mapper.Map<List<GetApplicationResponse>>(list);
    }
}
