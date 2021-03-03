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
    public class CreateModel : PageModel
    {
        private readonly ICommentService commentService;

        public CreateModel(ICommentService _commentService)
        {
            commentService = _commentService;
        }

        [BindProperty]
        public CommentsInputDto commentInput { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await commentService.Create(commentInput);

            return RedirectToPage("../User/Index");
        }
    }
}
