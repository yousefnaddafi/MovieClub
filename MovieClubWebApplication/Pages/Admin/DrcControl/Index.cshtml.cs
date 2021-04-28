using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Directors;
using App.Core.ApplicationService.Dtos.DirectorDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Admin.DrcControl
{
    public class IndexModel : PageModel
    {
        private readonly IDirectorService _directorService;
        public IndexModel(IDirectorService directorService)
        {
            _directorService = directorService;
        }
        [BindProperty]
        public List<DirectorOutputDto> directorInput { get; set; }
        public async Task OnGetAsync()
        {
            directorInput = await _directorService.GetAll();
        }

    }
}
