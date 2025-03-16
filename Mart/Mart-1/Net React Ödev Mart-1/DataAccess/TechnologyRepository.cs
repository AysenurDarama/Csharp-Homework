using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TechnologyRepository : IRepository<Technology>
    {
        private readonly ApplicationDbContext _context;

        public TechnologyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Technology entity)
        {
            _context.Technologies.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Technology entity)
        {
            _context.Technologies.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Technology entity)
        {
            _context.Technologies.Update(entity);
            _context.SaveChanges();
        }

        public Technology GetById(int id)
        {
            return _context.Technologies.Find(id);
        }

        public IEnumerable<Technology> GetAll()
        {
            return _context.Technologies.Include(t => t.ProgrammingLanguage).ToList();
        }
    }



}
