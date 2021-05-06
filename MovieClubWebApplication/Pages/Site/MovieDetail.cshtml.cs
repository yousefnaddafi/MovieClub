using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.Dtos.MovieDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace MovieClubWebApplication.Pages.Site
{
    public class MovieDetailModel : PageModel
    {
        private readonly IMovieService movieService;

        public MovieDetailModel(IMovieService _movieService)
        {
            this.movieService = _movieService;
        }

        [BindProperty]
        public MovieOutputDto movieDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            movieDetails = await movieService.Get(id.Value);

            if (movieDetails == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
