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

        public GenreMovie Update(GenreMovie item)
        {
            this.genreMovieRepository.Update(item);
            genreMovieRepository.Save();
            return item;
        }

        public int Delete(int id)
        {
            if (genreMovieRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault())
            {
                throw new InvalidIdException("Wrong Id");
            }
            genreMovieRepository.Delete(id);
            return id;
        }

        public Task<GenreMovie> Get(int id)
        {
            if (genreMovieRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault())
            {
                throw new InvalidIdException("Wrong Id");
            }
            return genreMovieRepository.Get(id);
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
