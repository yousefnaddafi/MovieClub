using App.Core.ApplicationService.Dtos.DirectorDtos;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.Directors
{
    public interface IDirectorService
    {
        Task<string> Create(DirectorInputDto inputDto);
        Entities.Model.Directors Update(Entities.Model.Directors item);
        int Delete(int id);
        Task<Entities.Model.Directors> Get(int id);
        Task<List<Entities.Model.Directors>> GetAll();
        List<Entities.Model.Directors> GetQuery();
        Task<Entities.Model.Directors> SaveChangesAsync();

    }
}
