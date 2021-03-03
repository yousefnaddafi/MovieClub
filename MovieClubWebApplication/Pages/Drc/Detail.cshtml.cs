using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Directors;
using App.Core.ApplicationService.Dtos.DirectorDtos;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Drc
{
    public class DetailModel : PageModel
    {
       private readonly IDirectorService _directorService;
       public DetailModel(IDirectorService directorService)
        {
            _directorService = directorService;
        }
        public DirectorInputDto directorDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            directorDetail = await _directorService.Get(id.Value);

            if (directorDetail == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}