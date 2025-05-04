using Business.Abstract;
using Entities;
using Repositories.Abstract;
using Repositories.Concrete;
using Repositories.EfRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class InstructorManager : IInstructorService
{
    private readonly IInstructorRepository _instructorRepository;

    public InstructorManager(IInstructorRepository instructorRepository)
    {
        _instructorRepository = instructorRepository;
    }

    public async Task<List<Instructor>> GetAllAsync()
    {
        return (await _instructorRepository.GetAllAsync()).ToList();
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

