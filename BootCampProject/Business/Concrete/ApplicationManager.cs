using AutoMapper;
using Business.Abstract;
using Business.Dtos.Requests.Application;
using Business.Dtos.Responses.Application;
using Entities;
using Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class ApplicationManager : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IMapper _mapper;

    public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper)
    {
        _applicationRepository = applicationRepository;
        _mapper = mapper;
    }

    public async Task<CreatedApplicationResponse> AddAsync(CreateApplicationRequest request)
    {
        Application application = _mapper.Map<Application>(request);
        Application createdApp = await _applicationRepository.AddAsync(application);
        return _mapper.Map<CreatedApplicationResponse>(createdApp);
    }

    public async Task<UpdatedApplicationResponse> UpdateAsync(UpdateApplicationRequest request)
    {
        Application application = _mapper.Map<Application>(request);
        Application updatedApp = await _applicationRepository.UpdateAsync(application);
        return _mapper.Map<UpdatedApplicationResponse>(updatedApp);
    }

    public async Task<DeletedApplicationResponse> DeleteAsync(int id)
    {
        Application application = await _applicationRepository.GetByIdAsync(id);
        await _applicationRepository.DeleteAsync(application);
        return new DeletedApplicationResponse { Id = id };
    }

    public async Task<GetApplicationResponse> GetByIdAsync(int id)
    {
        Application application = await _applicationRepository.GetByIdAsync(id);
        return _mapper.Map<GetApplicationResponse>(application);
    }

    public async Task<List<GetApplicationResponse>> GetListAsync()
    {
        var list = await _applicationRepository.GetAllAsync();
        return _mapper.Map<List<GetApplicationResponse>>(list);
    }
}
