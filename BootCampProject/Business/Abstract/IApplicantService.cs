using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IApplicantService
{
    Task<List<Applicant>> GetAllAsync();
    Task<Applicant> GetByIdAsync(int id);
    Task<Applicant> AddAsync(Applicant applicant);
    Task<Applicant> UpdateAsync(Applicant applicant);
    Task DeleteAsync(Applicant applicant);
}
