using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.Directors
{
    public class DirectorService : IDirectorService
    {
        private readonly IMovieRepository<Director> directorRepository;

        public DirectorService(IMovieRepository<Director> _directorRepository)
        {
            this.directorRepository = _directorRepository;
        }

        public int Create(Director inputDto)
        {
            directorRepository.Insert(inputDto);
            directorRepository.Save();
            return inputDto.Id;
        }

        public Director Update(Director item)
        {
            this.directorRepository.Update(item);
            directorRepository.Save();
            return item;
        }

        public int Delete(int id)
        {
            directorRepository.Delete(id);
            return id;
        }

        public Task<Director> Get(int id)
        {
            return directorRepository.Get(id);
        }

        public Task<List<Director>> GetAll()
        {
            return directorRepository.GetAll();
        }

        public List<Director> GetQuery()
        {
            return directorRepository.GetQuery().ToList();
        }
    }
}
