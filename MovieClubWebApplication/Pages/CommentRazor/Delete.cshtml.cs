using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Commentts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.CommentRazor
{
    public class DeleteModel : PageModel
    {
        private readonly ICommentService commentService;

        public DeleteModel(ICommentService _commentService)
        {
            commentService = _commentService;
        }

        [BindProperty]
        public int commnetId { get; set; }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            commentService.Delete(id);

            return RedirectToPage("../User/Index");
        }
    }
}
