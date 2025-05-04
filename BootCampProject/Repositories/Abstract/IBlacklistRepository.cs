using Core.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstract;

public interface IBlacklistRepository : IAsyncRepository<Blacklist>
{
}
