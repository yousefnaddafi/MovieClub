using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using App.Core.ApplicationService.Dtos.DirectorDtos;
using App.Core.Entities.Exceptions;

namespace App.Core.ApplicationService.ApplicationSerrvices.Directors
{
    public class DirectorService : IDirectorService
    {
        private readonly IMovieRepository<Entities.Model.Directors> directorRepository;
        private readonly IMapper mapper;
        public DirectorService(IMovieRepository<Entities.Model.Directors> _directorRepository,IMapper mapper)
        {
            this.directorRepository = _directorRepository;
            this.mapper = mapper;
        }

        public async Task<string> Create(DirectorInputDto inputDto)
        {
            try
            {
                var director = mapper.Map<Entities.Model.Directors>(inputDto);
                directorRepository.Insert(director);
                await directorRepository.Save();
                return inputDto.FullName;
            }
         catch(Exception ex)
            {
                throw;
            }
        }

        public Entities.Model.Directors Update(Entities.Model.Directors item)
        {
            this.directorRepository.Update(item);
            directorRepository.Save();
            return item;
        }

        public int Delete(int id)
        {
            if (directorRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault())
            {
                throw new InvalidIdException("Wrong Id");
            }
            directorRepository.Delete(id);
            return id;
        }

        public Task<Entities.Model.Directors> Get(int id)
        {
            if (directorRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault())
            {
                throw new InvalidIdException("Wrong Id");
            }
            return directorRepository.Get(id);
        }

        public Task<List<Entities.Model.Directors>> GetAll()
        {
            return directorRepository.GetAll();
        }

        public List<Entities.Model.Directors> GetQuery()
        {
            return directorRepository.GetQuery().ToList();
        }
       public Task SaveChangesAsync()
        {
            return  directorRepository.Save();
        }
    }
}
