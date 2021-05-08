using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationSerrvices.Actors;
using App.Core.ApplicationService.Dtos.ActorDtos;
using App.Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieClubWebApplication.Pages.Admin.ActorRazor
{
    public class IndexModel : PageModel
    {
        private readonly IActorService actorService;
        public IndexModel(IActorService _actorService)
        {
            actorService = _actorService;
        }
        [BindProperty]
        public List<ActorOutputDto> actors { get; set; }
        public async Task OnGetAsync(int id)
        {
            actors = await actorService.GetAll();
        }

    }
}
