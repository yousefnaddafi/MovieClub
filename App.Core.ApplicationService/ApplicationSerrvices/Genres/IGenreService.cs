using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.ApplicationSerrvices.Genres
{
    public interface IGenreService
    {
        int Create(Genre inputDto);
        Genre Update(Genre item);
        int Delete(int id);
        Genre Get(int id);
        List<Genre> GetAll();
    }
}
