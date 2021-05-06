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


        public UserService(IMovieRepository<User> _repository, IMovieRepository<Favorite> FavRepository, IMapper mapper)
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

        public async Task<UserOutputDto> Update(UserUpdateDto inputDto)
        {

            var mappedUser = mapper.Map<User>(inputDto);

            await userRepository.Update(mappedUser);
            await userRepository.Save();
            return mapper.Map<UserOutputDto>(mappedUser);
        }

        public async Task<int> Delete(int id)
        {
            var item = userRepository.GetQuery().FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                await userRepository.Delete(id);
                await userRepository.Save();
                return id;
            }
            else
            {
                return 0;
            }
        }

        public async Task<UserOutputDto> Get(int id)
        {
            var user = userRepository.GetQuery().FirstOrDefault(x => x.Id == id);
            var mappedUser = mapper.Map<UserOutputDto>(user);
            return mappedUser;
        }

        public async Task<List<UserOutputDto>> GetAll()
        {
            List<User> users = new List<User>();
            users = userRepository.GetQuery().ToList();

            List<UserOutputDto> result = new List<UserOutputDto>();

            foreach (var item in users)
            {
                var mappedUser = mapper.Map<UserOutputDto>(item);
                result.Add(mappedUser);
            }

            return result;
        }

        public async Task Insert(UserInputDto inputDto)
        {
            var RegisterUser = mapper.Map<User>(inputDto);
            userRepository.Insert(RegisterUser);
            await userRepository.Save();
        }

        public async Task AddFavorites(FavoriteInputDto inputDto)
        {
            foreach (var item in inputDto.Favorites)
            {
                var Fav = new Favorite();
                Fav.GenreTitle = item;
                Fav.UserId = inputDto.UserId;
                FavoriteRepository.Insert(Fav);
                await FavoriteRepository.Save();
            }

        }
    }
}







