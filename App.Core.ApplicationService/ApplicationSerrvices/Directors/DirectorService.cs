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

        public async Task<string> Update(DirectorUpdateDto item)
        {
            var drc = mapper.Map<Entities.Model.Directors>(item);
            this.directorRepository.Update(drc);
            await directorRepository.Save();
            return $"{item.Id}is update";
        }

        public async Task<int> Delete(int id)
        {
            // var dltDirector = directorRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault();
            //if(dltDirector.ToString()==null)
            //{
            //  return 0;

            //}
            var directortoDelete = directorRepository.GetQuery().FirstOrDefault(x => x.Id == id);
            if(directortoDelete != null)
            {
               await directorRepository.Delete(id);  
               await directorRepository.Save();
            }

          return id;
        
          
        }

        public async Task<DirectorOutputDto> Get(int id)
        {
            //if (directorRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault())
            //{
            //    throw new InvalidIdException("Wrong Id");
            //}
            var directorss = directorRepository.GetQuery().FirstOrDefault(x => x.Id == id);

            List<DirectorOutputDto> result = new List<DirectorOutputDto>();

            var mappedDirectorss = mapper.Map<DirectorOutputDto>(directorss);
            result.Add(mappedDirectorss);
            return mappedDirectorss;
        }


        public async Task<List<DirectorOutputDto>> GetAll()
        {
            var directorrr = directorRepository.GetQuery().ToList();
            List<DirectorOutputDto> result = new List<DirectorOutputDto>();

            foreach (var item in directorrr)
            {
                var mappedDirectors = mapper.Map<DirectorOutputDto>(item);
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
