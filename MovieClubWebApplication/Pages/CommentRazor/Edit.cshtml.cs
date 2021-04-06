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
        public CommentsOutputDto inputDto { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            inputDto = await commentService.Get(id);

            if (inputDto == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            CommentsUpdateDto tempCommentUpdate = new CommentsUpdateDto();
            tempCommentUpdate.Id = inputDto.Id;
            tempCommentUpdate.MovieId = inputDto.MovieId;


            await commentService.Update(tempCommentUpdate);

            return RedirectToPage("../User/Index");
        }


        

        
    }
}
