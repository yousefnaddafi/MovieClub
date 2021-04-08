using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.CommentDtos;
using App.Core.Entities.Model;

namespace App.Core.ApplicationService.ApplicationSerrvices.Commentts
{
    public interface ICommentService
    {
        Task Create(CommentsInputDto inputDto);
        Task<CommentsOutputDto> Update(CommentsUpdateDto item);
        Task<int> Delete(int id);
        Task<CommentsOutputDto> Get(int id);
        Task<List<CommentsOutputDto>> GetAll();
        Task Insert(CommentsInputDto inputDto);

    }
}
