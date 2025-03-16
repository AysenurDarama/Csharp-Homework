using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProgrammingLanguageRepository : IRepository<ProgrammingLanguage>
    {
        private readonly ApplicationDbContext _context;

        public ProgrammingLanguageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(ProgrammingLanguage entity)
        {
            _context.ProgrammingLanguages.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(ProgrammingLanguage entity)
        {
            _context.ProgrammingLanguages.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(ProgrammingLanguage entity)
        {
            _context.ProgrammingLanguages.Update(entity);
            _context.SaveChanges();
        }

        public ProgrammingLanguage GetById(int id)
        {
            return _context.ProgrammingLanguages.Find(id);
        }

        public IEnumerable<ProgrammingLanguage> GetAll()
        {
            return _context.ProgrammingLanguages.ToList();
        }
    }



}
