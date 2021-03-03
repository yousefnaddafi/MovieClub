using System;
namespace App.Core.ApplicationService.Dtos.CommentDtos
{
    public class CommentsUpdateDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int MovieId { get; set; }
    }
}
