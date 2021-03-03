using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Actors;
using App.Core.ApplicationService.Dtos.ActorDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.ActorRazor
{
    public class DetailModel : PageModel
    {
        private readonly IActorService _actorService;
        public DetailModel(IActorService actorService)
        {
            _actorService = actorService;
        }
        public ActorInputDto actorDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            actorDetail = await _actorService.Get(id.Value);

            if (actorDetail == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
