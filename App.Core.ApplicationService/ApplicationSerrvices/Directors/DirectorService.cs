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
        private readonly IMovieRepository<Director> DirectorRepository;

        public DirectorService(IMovieRepository<Director> DirectorRepository)
        {
            this.DirectorRepository = DirectorRepository;
        }
        public int Create(Director inputDto)
        {

            DirectorRepository.Insert(inputDto);
            DirectorRepository.Save();
            return inputDto.Id;
        }
        public Director Update(Director item)
        {
            this.DirectorRepository.Update(item);
            DirectorRepository.Save();
            return item;
        }
        public int Delete(int id)
        {
            DirectorRepository.Delete(id);
            return id;
        }

        public Task<Director> Get(int id)
        {
            return DirectorRepository.GetAsync(id);
        }

        public Task<List<Director>> GetAll()
        {
            return DirectorRepository.GetAllAsync();
        }
        public IQueryable<Director> GetQuery()
        {
            return DirectorRepository.GetQuery();
        }
    }
}
