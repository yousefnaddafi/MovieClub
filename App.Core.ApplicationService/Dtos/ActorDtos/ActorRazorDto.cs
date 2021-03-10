using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.ActorDtos
{
    public class ActorRazorDto:IHasIdentity
    {
        public int Id { get; set; }
        public string ActorName { get; set; }
    }
}
