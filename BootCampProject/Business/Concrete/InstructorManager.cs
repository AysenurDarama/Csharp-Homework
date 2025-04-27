using Business.Abstract;
using Entities;
using Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class InstructorManager : IInstructorService
{
    private readonly InstructorRepository _instructorRepository;

    public InstructorManager(InstructorRepository instructorRepository)
    {
        _instructorRepository = instructorRepository;
    }

    public async Task<List<Instructor>> GetAllAsync()
    {
        return (List<Instructor>)await _instructorRepository.GetAllAsync();
    }

    public async Task<Instructor> GetByIdAsync(int id)
    {
        return await _instructorRepository.GetByIdAsync(id);
    }

    public async Task<Instructor> AddAsync(Instructor instructor)
    {
        return await _instructorRepository.AddAsync(instructor);
    }

    public async Task<Instructor> UpdateAsync(Instructor instructor)
    {
        return await _instructorRepository.UpdateAsync(instructor);
    }

    public async Task DeleteAsync(Instructor instructor)
    {
        await _instructorRepository.DeleteAsync(instructor);
    }
}
