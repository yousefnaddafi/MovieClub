using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.CommentDtos;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using AutoMapper;

namespace App.Core.ApplicationService.ApplicationSerrvices.Commentts
{
    public class CommentService : ICommentService
    {
        private readonly IMovieRepository<Comment> commentRepository;
        private readonly IMapper mapper;

        public CommentService(IMovieRepository<Comment> _commentRepository, IMapper _mapper) {
            commentRepository = _commentRepository;
            mapper = _mapper;
        }

        public async Task Create(CommentsInputDto inputDto) {
            var temp = mapper.Map<Comment>(inputDto);
            commentRepository.Insert(temp);
            await commentRepository.Save();
        }

        public async Task<CommentsOutputDto> Update(CommentsUpdateDto commentsUpdateDto) {
            var tempComment = mapper.Map<Comment>(commentsUpdateDto);
            await commentRepository.Update(tempComment);
            await commentRepository.Save();
            return mapper.Map<CommentsOutputDto>(tempComment);
        }

        public async Task<int> Delete(int id) {
            var item = commentRepository.GetQuery().FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                await commentRepository.Delete(id);
                await commentRepository.Save();
                return id;
            }
            else
            {
                return 0;
            }
        }

        public async Task<CommentsOutputDto> Get(int id) {
            var user = commentRepository.GetQuery().FirstOrDefault(x => x.Id == id);
            var mappedUser = mapper.Map<CommentsOutputDto>(user);
            return mappedUser;
        }

        public async Task<List<CommentsOutputDto>> GetAll() {
            List<Comment> comments = new List<Comment>();
            comments = commentRepository.GetQuery().ToList();

            List<CommentsOutputDto> result = new List<CommentsOutputDto>();

            foreach (var item in comments)
            {
                var mappedComment = mapper.Map<CommentsOutputDto>(item);
                result.Add(mappedComment);
            }

            return result;
        }

        public List<Comment> GetQuery() {
            return commentRepository.GetQuery().ToList();
        }

        public async Task Insert(CommentsInputDto inputDto) {

            var mappedComment = mapper.Map<Comment>(inputDto);
            commentRepository.Insert(mappedComment);
            await commentRepository.Save();
        }


        
    }
}
