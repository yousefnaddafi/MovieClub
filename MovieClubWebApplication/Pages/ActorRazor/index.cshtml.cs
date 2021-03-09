using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Actors;
using App.Core.ApplicationService.Dtos.ActorDtos;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.ActorRazor
{
    public class IndexModel : PageModel
    {
        private readonly IActorService _actorService;
        public IndexModel(IActorService actorService)
        {
            _actorService = actorService;
        }
        [BindProperty]
        public List<ActorInputDto> actorInput { get; set; }
        [BindProperty]
        public List<Actor> Actors { get; set; }

        public async Task OnGetAsync()
        {
            actorInput = await _actorService.GetAll();
        }
    }
}
