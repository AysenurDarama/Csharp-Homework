using Business.Dtos.Requests.Application;
using Business.Dtos.Responses.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IApplicationService
{
    Task<CreatedApplicationResponse> AddAsync(CreateApplicationRequest request);
    Task<UpdatedApplicationResponse> UpdateAsync(UpdateApplicationRequest request);
    Task<DeletedApplicationResponse> DeleteAsync(int id);
    Task<GetApplicationResponse> GetByIdAsync(int id);
    Task<List<GetApplicationResponse>> GetListAsync();
}
