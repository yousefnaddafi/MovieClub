using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.ActorMovies;
using App.Core.ApplicationService.Dtos.ActorMovieDtos;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.ActorMovieRazor
{
    public class EditModel : PageModel
    {
        private readonly IActorMovieService _actorMovieService;
        public EditModel(IActorMovieService actorMovieService)
        {
            _actorMovieService = actorMovieService;
        }
        [BindProperty]
        public List<ActorMovieInputDto> actorMoviesEdit { get; set; }
        public async Task<IAsyncResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return (IAsyncResult)NotFound();
            }

            actorMoviesEdit = await _actorMovieService.GetAll();

            if (actorMoviesEdit == null)
            {
                return (IAsyncResult)NotFound();
            }
            return (IAsyncResult)Page();
        }

        public async Task<IActionResult> OnPostAsync(ActorMovie actorMovie)
        {
            var actorMovieToEdit = _actorMovieService.Update(actorMovie);

            if (actorMovieToEdit == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<ActorMovie>(
                actorMovieToEdit,
                "actorMovie",
                s => s.Id))
            {

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
