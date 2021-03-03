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

        public async Task<string> Create(CommentsInputDto inputDto) {
            var temp = mapper.Map<Comment>(inputDto);
            commentRepository.Insert(temp);
            await commentRepository.Save();
            return temp.Text;
        }

        public Comment Update(CommentsUpdateDto commentsUpdateDto) {
            var tempComment = mapper.Map<Comment>(commentsUpdateDto);
            commentRepository.Update(tempComment);
            commentRepository.Save();
            return tempComment;
        }

        public int Delete(int id) {
            commentRepository.Delete(id);
            return id;
        }

        public async Task<Comment> Get(int id) {
            return await commentRepository.Get(id);
        }

        public Task<List<Comment>> GetAll() {
            return commentRepository.GetAll();
        }

        public List<Comment> GetQuery() {
            return commentRepository.GetQuery().ToList();
        }

        public int AddComment(CommentsInputDto inputDto) {

            var mappedComment = mapper.Map<Comment>(inputDto);
            commentRepository.Insert(mappedComment);
            commentRepository.Save();
            return mappedComment.Id;
        }


        
    }
}
