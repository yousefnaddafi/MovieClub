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
        int Create(Director inputDto);
        Director Update(Director item);
        int Delete(int id);
        Task<Director> Get(int id);
        Task<List<Director>> GetAll();
        IQueryable<Director> GetQuery();

    }
}
