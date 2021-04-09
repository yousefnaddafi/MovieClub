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

        public GenreMovieService(IMovieRepository<GenreMovie> _genreMovieRepository, IMapper mapper)
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

        public async Task<string> Update(GenreMovieUpdateDto item)
        {
            var GMovie = mapper.Map<GenreMovie>(item);
            await this.genreMovieRepository.Update(GMovie);
            await genreMovieRepository.Save();
            return $"{item.Id }is update";
            ;
        }

        public async Task<int> Delete(int id)
        {
            var item = genreMovieRepository.GetQuery().FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                await genreMovieRepository.Delete(id);
                await genreMovieRepository.Save();
                return id;
            }
            else
            {
                return 0;
            }
        }

        public async Task<GenreMovieOutput> Get(int id)
        {

            var GenresMovies = genreMovieRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault();
            var mappedGenreMovie = mapper.Map<GenreMovieOutput>(GenresMovies);
            return mappedGenreMovie;

        }

        public async Task<List<GenreMovieOutput>> GetAll()
        {
            List<GenreMovie> genreMovies = new List<GenreMovie>();

            genreMovies = genreMovieRepository.GetQuery().ToList();
            List<GenreMovieOutput> genreMovieOutputs = new List<GenreMovieOutput>();

            foreach (var item in genreMovies)
            {

                var mappedGenremovies = mapper.Map<GenreMovieOutput>(item);
                genreMovieOutputs.Add(mappedGenremovies);
            }
            return genreMovieOutputs;
        }

       // public List<GenreMovieOutput> GetQuery()
        //{
          //  return genreMovieRepository.GetQuery().ToList();
        //}
    }
}
