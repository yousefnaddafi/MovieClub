using App.Core.ApplicationService.Dtos.FavoriteDtos;
using App.Core.ApplicationService.Dtos.UserDto;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Exceptions;
using App.Core.Entities.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.Users
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IMovieRepository<User> userRepository;
        private readonly IMovieRepository<Favorite> FavoriteRepository;


        public UserService(IMovieRepository<User> _repository,IMovieRepository<Favorite> FavRepository ,IMapper mapper)
        {
            FavoriteRepository = FavRepository;
            userRepository = _repository;
            this.mapper = mapper;
        }

        public async Task Create(UserInputDto inputDto)
        {
            try
            {
                var RegisterUser = mapper.Map<User>(inputDto);

                userRepository.Insert(RegisterUser);
                await userRepository.Save();
              
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<User> Update(UserUpdateDto inputDto)
        {

            var RegisterUser = mapper.Map<User>(inputDto);

            await userRepository.Update(RegisterUser);
            await userRepository.Save();
            return RegisterUser;
        }

        public async Task<int> Delete(int id)
        {
            var item = userRepository.GetQuery().Where(x => x.Id == id).FirstOrDefault();
            if (item == null)
            {
                throw new InvalidIdException("Wrong Id");
            }
            await userRepository.Delete(id);
            await userRepository.Save();
            return id;
        }

        public Task<User> Get(int id)
        {
            if (userRepository.GetQuery().Select(x => x.Id != id).FirstOrDefault())
            {
                throw new InvalidIdException("Wrong Id");
            }
            return userRepository.Get(id);
        }

        public Task<List<User>> GetAll()
        {
            return userRepository.GetAll();
        }
        //
        public async Task Insert(UserInputDto inputDto)
        {
            var RegisterUser = mapper.Map<User>(inputDto);
            userRepository.Insert(RegisterUser);
            await userRepository.Save();
        }

        public async Task AddFavorites(FavoriteInputDto inputDto)
        {
            foreach(var item in inputDto.Favorites)
            {
                var Fav = new Favorite();
                Fav.GenreTitle = item;
                Fav.UserId= inputDto.UserId;
                FavoriteRepository.Insert(Fav);
                await FavoriteRepository.Save();
            }
            
        }
    }
}



            
        
    

