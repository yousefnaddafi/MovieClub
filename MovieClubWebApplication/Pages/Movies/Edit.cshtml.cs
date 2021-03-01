using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.Dtos.MovieDtos;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly IMovieService _movieService;
        public EditModel(IMovieService movieService)
        {
            _movieService= movieService;
        }
        [BindProperty]
        public List<MovieOutputDto> moviesEdit { get; set; }
        public async Task<IAsyncResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return (IAsyncResult)NotFound();
            }

            moviesEdit =await _movieService.GetAll();

            if (moviesEdit == null)
            {
                return (IAsyncResult)NotFound();
            }
            return (IAsyncResult)Page();
        }

        public async Task<IActionResult> OnPostAsync(MovieInputDto moviess)
        {
            var movieToEdit = _movieService.Update(moviess);

            if (movieToEdit == null)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
            }

        private bool MovieListExists(int id)
        {
            return _movieService.GetQuery().Any(e => e.Id == id);
        }
    }
    
}
