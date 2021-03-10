using App.Core.ApplicationService.Dtos.CountryDtos;
using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationSerrvices.Countries
{
    public interface ICountryService
    {
        Task<string> Create(CountryInputDTO inputDto);
        Country Update(CountryRazorDto item);
        int Delete(int id);
        Task<CountryOutputDto> Get(int id);
        Task<List<CountryOutputDto>> GetAll();
        List<Country> GetQuery();
    }
}
