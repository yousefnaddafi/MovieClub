using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.ApplicationSerrvices.Countries
{
    public interface ICountryService
    {
        int Create(Country inputDto);
        Country Update(Country item);
        int Delete(int id);
        Country Get(int id);
        List<Country> GetAll();
    }
}
