using System;
using App.Core.Entities.Model;

namespace App.Core.ApplicationService.ApplicationSerrvices.Comments
{
    public interface ICommentService
    {
        int Create(Comment _comment);
        void AddComment(Comment _comment);
    }
}
