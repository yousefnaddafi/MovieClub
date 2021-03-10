using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.DirectorDtos
{
   public class DirectorUpdateDto
    {
        public int Id { get; set; }
        public string DirectorName { get; set; }
        public List<string> Movies { get; set; }
    }
}
