using AutoMapper;
using Business.Abstract;
using Business.Dtos.Requests.Instructor;
using Business.Dtos.Responses.Instructor;
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
    private readonly IMapper _mapper;

    public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper)
    {
        _instructorRepository = instructorRepository;
        _mapper = mapper;
    }

    public async Task<List<GetInstructorResponse>> GetAllAsync()
    {
        var instructors = await _instructorRepository.GetAllAsync();
        return _mapper.Map<List<GetInstructorResponse>>(instructors);
    }

    public async Task<GetInstructorResponse> GetByIdAsync(int id)
    {
        var instructor = await _instructorRepository.GetByIdAsync(id);
        return _mapper.Map<GetInstructorResponse>(instructor);
    }

    public async Task<CreatedInstructorResponse> AddAsync(CreateInstructorRequest request)
    {
        var instructor = _mapper.Map<Instructor>(request);
        var added = await _instructorRepository.AddAsync(instructor);
        return _mapper.Map<CreatedInstructorResponse>(added);
    }

    public async Task<UpdatedInstructorResponse> UpdateAsync(UpdateInstructorRequest request)
    {
        var instructor = _mapper.Map<Instructor>(request);
        var updated = await _instructorRepository.UpdateAsync(instructor);
        return _mapper.Map<UpdatedInstructorResponse>(updated);
    }

    public async Task<DeletedInstructorResponse> DeleteAsync(int id)
    {
        var instructor = await _instructorRepository.GetByIdAsync(id);
        var deleted = await _instructorRepository.DeleteAsync(instructor);
        return _mapper.Map<DeletedInstructorResponse>(deleted);
    }
}

