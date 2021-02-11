using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using App.Core.ApplicationService.Dtos.DirectorDtos;

namespace App.Core.ApplicationService.ApplicationSerrvices.Directors
{
    public class DirectorService : IDirectorService
    {
        private readonly IMovieRepository<Director> directorRepository;
        private readonly IMapper mapper;
        public DirectorService(IMovieRepository<Director> _directorRepository,IMapper mapper)
        {
            this.directorRepository = _directorRepository;
            this.mapper = mapper;
        }

        public async Task<string> Create(DirectorInputDto inputDto)
        {
            try
            {
                var director = mapper.Map<Director>(inputDto);
                directorRepository.Insert(director);
                await directorRepository.Save();
                return inputDto.FullName;
            }
         catch(Exception ex)
            {
                throw;
            }
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
