using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Actors;
using App.Core.ApplicationService.Dtos.ActorDtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.ActorRazor
{
    public class DetailModel : PageModel
    {
        private readonly IActorService _actorService;
        private readonly IMapper mapper;
        public DetailModel(IActorService actorService, IMapper _mapper)
        {
            _actorService = actorService;
            mapper = _mapper;
        }
        public ActorOutputDto actorDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actorOutput = await _actorService.Get(id.Value);
            actorDetail = mapper.Map<ActorOutputDto>(actorOutput);

            if (actorDetail == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
