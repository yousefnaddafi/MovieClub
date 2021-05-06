using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Genres;
using App.Core.ApplicationService.Dtos.GenreDto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.GenreRazor
{
    public class DetailModel : PageModel
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        public DetailModel(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }
        public GenreOutPutDto genreDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tempUserOutput = await _genreService.Get(id.Value);
            genreDetail = _mapper.Map<GenreOutPutDto>(tempUserOutput);

            if (genreDetail == null)
            {
                return NotFound();
            }
            return Page();
        }

        //public async Task<IActionResult> OnGetAsync(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        genreDetail = await _genreService.Get(id.Value);

        //        if (genreDetail == null)
        //        {
        //            return NotFound();
        //        }
        //        return Page();
        //    }
    }
}

