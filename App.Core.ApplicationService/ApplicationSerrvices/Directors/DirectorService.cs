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
using Microsoft.EntityFrameworkCore;

namespace App.Core.ApplicationService.ApplicationSerrvices.Directors
{
    public class DirectorService : IDirectorService
    {
        private readonly IMovieRepository<Entities.Model.Directors> directorRepository;
        private readonly IMapper mapper;
        public DirectorService(IMovieRepository<Entities.Model.Directors> _directorRepository, IMapper mapper)
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
            catch (Exception ex)
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

        public async Task<DirectorInputDto> Get(int id)
        {
            if (directorRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault())
            {
                throw new InvalidIdException("Wrong Id");
            }
            var directorss = directorRepository.GetQuery().FirstOrDefault(x => x.Id == id);

            List<DirectorInputDto> result = new List<DirectorInputDto>();

            var mappedDirectorss = mapper.Map<DirectorInputDto>(directorss);
            result.Add(mappedDirectorss);
            return mappedDirectorss;
        }


        public async Task<List<DirectorInputDto>> GetAll()
        {
            var directorrr = directorRepository.GetQuery().Select(x => x.DirectorName).ToList();
            List<DirectorInputDto> result = new List<DirectorInputDto>();

            foreach (var item in directorrr)
            {
                var mappedDirectors = mapper.Map<DirectorInputDto>(item);
                result.Add(mappedDirectors);
            }

            return result;
        }
        public List<Entities.Model.Directors> GetQuery()
        {
            return directorRepository.GetQuery().ToList();
        }        
        public async Task SaveChangesAsync()
        {
            await directorRepository.Save();
        }

    }
}
