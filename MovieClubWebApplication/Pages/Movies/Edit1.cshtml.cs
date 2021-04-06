//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using App.Core.ApplicationService.ApplicationSerrvices.Movies;
//using App.Core.ApplicationService.Dtos.MovieDtos;
//using App.Core.Entities.Model;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;

//namespace MovieClubWebApplication.Pages.Movies
//{
//    public class EditModel : PageModel
//    {
//        private readonly IMovieService _movieService;
//        public EditModel(IMovieService movieService)
//        {
//            _movieService = movieService;
//        }
//        [BindProperty]
//        public MovieInputUpdateDto updateDto { get; set; }
//        public async Task<IActionResult> OnPost()
//        {
//            if (!ModelState.IsValid)
//            {
//                return Page();
//            }
//            await _movieService.Update(updateDto);
//            return RedirectToPage("/Index");
//        }
//    }
//}
