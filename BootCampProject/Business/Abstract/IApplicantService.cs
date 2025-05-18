using Business.Dtos.Requests.Applicant;
using Business.Dtos.Responses.Applicant;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IApplicantService
{
    Task<List<GetApplicantResponse>> GetAllAsync();
    Task<GetApplicantResponse> GetByIdAsync(int id);
    Task<CreatedApplicantResponse> AddAsync(CreateApplicantRequest request);
    Task<UpdatedApplicantResponse> UpdateAsync(UpdateApplicantRequest request);
    Task<DeletedApplicantResponse> DeleteAsync(int id);
}

