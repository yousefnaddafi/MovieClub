using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.CommentDtos;
using App.Core.Entities.Model;

namespace App.Core.ApplicationService.ApplicationSerrvices.Commentts
{
    public interface ICommentService
    {
        Task<string> Create(CommentsInputDto inputDto);
        Comment Update(CommentsUpdateDto item);
        int Delete(int id);
        Task<Comment> Get(int id);
        Task<List<Comment>> GetAll();
        List<Comment> GetQuery();
        int AddComment(CommentsInputDto inputDto);

    }
}
