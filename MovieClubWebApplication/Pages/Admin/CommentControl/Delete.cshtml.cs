using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Commentts;
using App.Core.ApplicationService.Dtos.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Admin.CommentControl
{
    public class DeleteModel : PageModel
    {
        private readonly ICommentService commentService;

        public DeleteModel(ICommentService _commentService)
        {
            commentService = _commentService;
        }

        [BindProperty]
        public CommentsOutputDto tempUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            tempUser = await commentService.Get(id);

            if (tempUser == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            int deletedUser = await commentService.Delete(tempUser.Id);

            if (deletedUser == 0)
            {
                return NotFound();
            }

            return RedirectToPage("Index");
        }
    }
}
