using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.CommentDtos
{
   public class CommentsInputDto
    {
        public string Text { get; set; }
        public int MovieId { get; set; }
    }
}
