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
    public class EditModel : PageModel
    {
        private readonly ICommentService commentService;

        public EditModel(ICommentService _commentService)
        {
            commentService = _commentService;
        }

        [BindProperty]
        public CommentsUpdateDto inputDto { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            commentService.Update(inputDto);

            return RedirectToPage("../User/Index");
        }
    }
}
