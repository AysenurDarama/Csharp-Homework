using Entities;
using Repositories.Abstract;
using Repositories.Contexts;
using Repositories.EfRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositories.EfRepositories;

public class EfInstructorRepository : EfRepositoryBase<Instructor, BootcampContext>, IInstructorRepository
{
    public EfInstructorRepository(BootcampContext context) : base(context)
    {
    }
}

