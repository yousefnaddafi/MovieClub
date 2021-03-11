using App.Core.ApplicationService.Dtos.GenreMovieDtos;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Exceptions;
using App.Core.Entities.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.GenreMovies
{
    public class GenreMovieService : IGenreMovieService
    {
        private readonly IMovieRepository<GenreMovie> genreMovieRepository;
        private readonly IMapper mapper;

        public GenreMovieService(IMovieRepository<GenreMovie> _genreMovieRepository,IMapper mapper)
        {
            this.genreMovieRepository = _genreMovieRepository;
            this.mapper = mapper;
        }

        public async Task<int> Create(GenreMovieInputDto inputDto)
        {
            var temp = mapper.Map<GenreMovie>(inputDto);
            genreMovieRepository.Insert(temp);
            await genreMovieRepository.Save();
            return temp.Id;
        }

        public async Task<string> Update(GenreMovieInputDto item)
        {
            var GMovie = mapper.Map<GenreMovie>(item);
            this.genreMovieRepository.Update(GMovie);
          await genreMovieRepository.Save();
            return $"{item.Id }is update";
            ;
        }

        public async Task<int> Delete(int id)
        {
           var input= genreMovieRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault();
           if(input==null)
            {
                return 0;
            }
         await genreMovieRepository.Delete(id);
         await genreMovieRepository.Save();
            return id;
        }

        public async Task<GenreMovieInputDto> Get(int id)
        {

          var GenresMovies = genreMovieRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault();
                    
            var mappedDirectorss = mapper.Map<GenreMovieInputDto>(GenresMovies);
            List<GenreMovieInputDto> result = new List<GenreMovieInputDto>();
            result.Add(mappedDirectorss);
            return mappedDirectorss;
           
        }

        public Task<List<GenreMovie>> GetAll()
        {
            return genreMovieRepository.GetAll();
        }

        public List<GenreMovie> GetQuery()
        {
            return genreMovieRepository.GetQuery().ToList();
        }
    }
}
