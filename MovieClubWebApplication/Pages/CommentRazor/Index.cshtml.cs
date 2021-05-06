using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Commentts;
using App.Core.ApplicationService.Dtos.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.CommentRazor
{
    public class IndexModel : PageModel
    {
        private readonly ICommentService commentService;

        public IndexModel(ICommentService _commentService)
        {
            commentService = _commentService;
        }

        [BindProperty]
        public List<CommentsOutputDto> comments { get; set; }

        public async Task OnGetAsync()
        {
            comments = await commentService.GetAll();
        }
    }
}
