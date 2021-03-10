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
       Task<string> Update(DirectorUpdateDto item);
        Task<int> Delete(int id);
        Task<DirectorInputDto> Get(int id);
        Task<List<DirectorInputDto>> GetAll();
        List<Entities.Model.Directors> GetQuery();
        Task SaveChangesAsync();

    }
}
