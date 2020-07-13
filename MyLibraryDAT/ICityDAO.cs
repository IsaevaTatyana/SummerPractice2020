using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace PracticeMyLibraryDAT
{
    public interface ICityDAO
    {
        IEnumerable<City> GetCities();

        void AddCity(City city);

        void RemoveCity(int CityId);

    }
}
