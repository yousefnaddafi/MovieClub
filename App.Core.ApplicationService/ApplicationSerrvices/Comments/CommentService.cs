//using System;
//using App.Core.ApplicationService.Dtos.Comments;
//using App.Core.ApplicationService.IRepositories;
//using App.Core.Entities.Model;
//using AutoMapper;

//namespace App.Core.ApplicationService.ApplicationSerrvices.Comments
//{
//    public class CommentService
//    {
//        private readonly IMovieRepository<Comment> CommentRepository;
//        private readonly IMapper mapper;

//        public CommentService(IMovieRepository<Comment> CommentRepository, IMapper _mapper)
//        {
//            this.CommentRepository = CommentRepository;
//            mapper = _mapper;
//        }

//        //public void Create(Comment inputDto)
//        //{
//        //    CommentRepository.Insert(inputDto);
//        //    CommentRepository.Save();
//        //}

//        public void AddComment(CommentInputDto inputDto) {
//            var temp = mapper.Map<Comment>(inputDto);
//            CommentRepository.Insert(temp);
//        }
//    }
//}
