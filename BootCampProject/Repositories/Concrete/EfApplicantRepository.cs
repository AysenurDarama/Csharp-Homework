using Entities;
using Repositories.Abstract;
using Repositories.Contexts;
using Repositories.EfRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Concrete;

public class EfApplicantRepository : EfRepositoryBase<Applicant, BootcampContext>, IApplicantRepository
{
    public EfApplicantRepository(BootcampContext context) : base(context)
    {
    }
}
