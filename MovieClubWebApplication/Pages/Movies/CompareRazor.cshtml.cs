using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Movies;
using App.Core.ApplicationService.Dtos.MovieDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace MovieClubWebApplication.Pages.Movies
{
    public class Compare_RazorModel : PageModel
    {
        private readonly IMovieService _movieService;
        public Compare_RazorModel(MovieService movieService)
        {
            _movieService = movieService;
        }
        [BindProperty]
        public List<MovieOutputDto> compares { get; set; }

        [BindProperty]
        public MovieCompareInputDto inputcompares { get; set; }
        [BindProperty]
        public MovieOutputDto movieOutput1 { get; set; }
        [BindProperty]
        public MovieOutputDto movieOutput2 { get; set; }
       /* public async Task OnGet(int id1, int id2)
        {
            var movies = new MovieCompareInputDto();
            movies.MovieId1 = id1;
            movies.MovieId2 = id2;
            compares = await _movieService.Compare(movies);

        }
        /* public async Task<ActionResult> OnPost()
         {
             if (!ModelState.IsValid)
             {
                 return Page();
             }

             compares=  await _movieService.Compare(inputcompares);

              return  RedirectToPage("../Movies/Index");
         }
     }
     /*    public static string[] GetSearchMovie(string input)
         {
             List<string> moviess = new List<string>();
             using (SqlConnection conn = new SqlConnection())
             {
                 conn.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                 using (SqlCommand cmd = new SqlCommand())
                 {
                     cmd.CommandText = "select Title, Id from Movie where Title like @SearchText + '%'";
                     cmd.Parameters.AddWithValue("@SearchText", input);
                     cmd.Connection = conn;
                     conn.Open();
                     using (SqlDataReader sdr = cmd.ExecuteReader())
                     {
                         while (sdr.Read())
                         {
                             moviess.Add(string.Format("{0}-{1}", sdr["Title"], sdr["Id"]));
                         }
                     }
                     conn.Close();
                 }
             }
             return moviess.ToArray();
         }*/
    }
}
