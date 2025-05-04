using Business.Dtos.Requests.Bootcamp;
using Business.Dtos.Responses.Bootcamp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IBootcampService
{
    Task<CreatedBootcampResponse> AddAsync(CreateBootcampRequest request);
    Task<UpdatedBootcampResponse> UpdateAsync(UpdateBootcampRequest request);
    Task<DeletedBootcampResponse> DeleteAsync(int id);
    Task<GetBootcampResponse> GetByIdAsync(int id);
    Task<IList<GetBootcampResponse>> GetListAsync();
}
