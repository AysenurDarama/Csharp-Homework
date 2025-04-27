using Entities;
using Entities.Data;
using Repositories.Abstract;
using Repositories.EfRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Concrete;

public class InstructorRepository : EfRepositoryBase<Instructor>, IInstructorRepository
{
    public InstructorRepository(BootcampContext context) : base(context)
    {
    }
}
