using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.ApplicationSerrvices.Directors
{
    public interface IDirectorService
    {
        int Create(Director inputDto);
        Director Update(Director item);
        int Delete(int id);
        Director Get(int id);
        List<Director> GetAll();
    }
}
