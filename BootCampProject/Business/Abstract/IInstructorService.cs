using Business.Dtos.Requests.Instructor;
using Business.Dtos.Responses.Instructor;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IInstructorService
{
    Task<List<GetInstructorResponse>> GetAllAsync();
    Task<GetInstructorResponse> GetByIdAsync(int id);
    Task<CreatedInstructorResponse> AddAsync(CreateInstructorRequest request);
    Task<UpdatedInstructorResponse> UpdateAsync(UpdateInstructorRequest request);
    Task<DeletedInstructorResponse> DeleteAsync(int id);
}
