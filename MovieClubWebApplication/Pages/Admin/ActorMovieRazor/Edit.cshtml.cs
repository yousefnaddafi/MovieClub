using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.ActorMovies;
using App.Core.ApplicationService.Dtos.ActorMovieDtos;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Admin.ActorMovieRazor
{
    public class EditModel : PageModel
    {
        private readonly IActorMovieService actorMovieService;

        public EditModel(IActorMovieService _actorMovieService)
        {
            actorMovieService = _actorMovieService;
        }

        [BindProperty]
        public ActorMovieOutputDto inputDto { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            inputDto = await actorMovieService.Get(id);

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

            ActorMovieUpdateDto actorMovieUpdate = new ActorMovieUpdateDto();
            actorMovieUpdate.Id = inputDto.id;
            actorMovieUpdate.MovieId = inputDto.MovieId;
            actorMovieUpdate.ActorId = inputDto.ActorId;

            await actorMovieService.Update(actorMovieUpdate);

            return RedirectToPage("../ActorMovieRazor/Index");
        }  
    }
}
