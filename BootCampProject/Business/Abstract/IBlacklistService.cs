using Business.Dtos.Requests.Blacklist;
using Business.Dtos.Responses.Blacklist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IBlacklistService
{
    Task<CreatedBlacklistResponse> AddAsync(CreateBlacklistRequest request);
    Task<UpdatedBlacklistResponse> UpdateAsync(UpdateBlacklistRequest request);
    Task<DeletedBlacklistResponse> DeleteAsync(int id);
    Task<GetBlacklistResponse> GetByIdAsync(int id);
    Task<List<GetBlacklistResponse>> GetAllAsync();
    Task<IList<GetBlacklistResponse>> GetListAsync();
}
