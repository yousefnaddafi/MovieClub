using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.FavoriteDtos
{
    public class FavoriteInputDto
    {
        public List<string> Favorites { get; set; }
        public int UserId { get; set; }
    }
}
