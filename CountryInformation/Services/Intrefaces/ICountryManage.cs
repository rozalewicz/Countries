using CountryInfo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryInfo.Services.Intrefaces
{
    public interface ICountryManage<TModel>
    {
        Task<List<TModel>> ReadCountry();

        Task<bool> SaveCountry(TModel country);

    }
}
