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
    public class DeleteModel : PageModel
    {
        private readonly IMovieService _movieService;
        public DeleteModel(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [BindProperty]
        public MovieOutputDto movieDelete { get; set; }
        public async Task<IActionResult> OnGetAsync(int ? id)
        {
            if (id == null)
            {
                return  (IActionResult)NotFound();
            }
            movieDelete = await _movieService.Get(id.Value);
            if (movieDelete == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int ? id)
        {
            if (id == null)
            {
                return (IActionResult)NotFound();
            }
                      
            if(movieDelete != null)
            {
                _movieService.Delete(id.Value);
                 await _movieService.SaveChangesAsync();                
            }
            return RedirectToPage("/Index");
        }
    }
   
}
