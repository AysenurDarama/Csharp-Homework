using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IInstructorService
{
    Task<List<Instructor>> GetAllAsync();
    Task<Instructor> GetByIdAsync(int id);
    Task<Instructor> AddAsync(Instructor instructor);
    Task<Instructor> UpdateAsync(Instructor instructor);
    Task DeleteAsync(Instructor instructor);
}
