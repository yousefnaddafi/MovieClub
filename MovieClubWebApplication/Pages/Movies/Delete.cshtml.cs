using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.Dtos.MovieDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly IMovieService movieService;

        public DeleteModel(IMovieService _movieService)
        {
            this.movieService = _movieService;
        }

        //[BindProperty]
        //public MovieOutputDto movieDelete { get; set; }

        //public async Task<IActionResult> OnGetAsync(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    movieDelete = await _movieService.Get(id.Value);
        //    if (movieDelete == null)
        //    {
        //        return NotFound();
        //    }
        //    return Page();
        //}



        //public async Task<IActionResult> OnPostAsync(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    if (movieDelete != null)
        //    {
        //        _movieService.Delete(movieDelete.Id);
        //    }
        //    return RedirectToPage("../Index");
        //}

        [BindProperty]
        public int movieId { get; set; }

        public async Task<IActionResult> OnPost(int id)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            movieService.Delete(id);

            return RedirectToPage("../User/Index");
        }
    }
   
}
