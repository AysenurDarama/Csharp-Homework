using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProgrammingLanguageService
    {
        private readonly IRepository<ProgrammingLanguage> _programmingLanguageRepository;

        public ProgrammingLanguageService(IRepository<ProgrammingLanguage> programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public void AddProgrammingLanguage(ProgrammingLanguage programmingLanguage)
        {
            _programmingLanguageRepository.Add(programmingLanguage);
        }

        public void DeleteProgrammingLanguage(ProgrammingLanguage programmingLanguage)
        {
            _programmingLanguageRepository.Delete(programmingLanguage);
        }

        public void UpdateProgrammingLanguage(ProgrammingLanguage programmingLanguage)
        {
            _programmingLanguageRepository.Update(programmingLanguage);
        }

        public IEnumerable<ProgrammingLanguage> GetAllProgrammingLanguages()
        {
            return _programmingLanguageRepository.GetAll();
        }

        public ProgrammingLanguage GetProgrammingLanguageById(int id)
        {
            return _programmingLanguageRepository.GetById(id);
        }
    }


}
