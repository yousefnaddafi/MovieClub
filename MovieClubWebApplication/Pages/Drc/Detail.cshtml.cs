using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Actors;
using App.Core.ApplicationService.ApplicationSerrvices.Directors;
using App.Core.ApplicationService.Dtos.ActorDtos;
using App.Core.ApplicationService.Dtos.DirectorDtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Drc
{
    public class DetailModel : PageModel
    {
        private readonly IDirectorService _directorService;
        private readonly IMapper mapper;
        public DetailModel(IDirectorService directorService, IMapper _mapper)
        {
            _directorService = directorService;
            mapper = _mapper;
        }
        public DirectorOutputDto directorDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directorOutput = await _directorService.Get(id.Value);
            directorDetail = mapper.Map<DirectorOutputDto>(directorOutput);

            if (directorDetail == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
