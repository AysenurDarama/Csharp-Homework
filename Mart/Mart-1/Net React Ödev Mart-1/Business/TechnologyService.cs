using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TechnologyService
    {
        private readonly IRepository<Technology> _technologyRepository;

        public TechnologyService(IRepository<Technology> technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public void AddTechnology(Technology technology)
        {
            _technologyRepository.Add(technology);
        }

        public void DeleteTechnology(Technology technology)
        {
            _technologyRepository.Delete(technology);
        }

        public void UpdateTechnology(Technology technology)
        {
            _technologyRepository.Update(technology);
        }

        public IEnumerable<Technology> GetAllTechnologies()
        {
            return _technologyRepository.GetAll();
        }

        public Technology GetTechnologyById(int id)
        {
            return _technologyRepository.GetById(id);
        }
    }


}
