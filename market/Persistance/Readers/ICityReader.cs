using System.Collections.Generic;
using System.Threading.Tasks;
using Algorithm.Model;

namespace Database.Persistance.Readers
{
    public interface ICityReader
    {
        Task<IList<City>> GetSafeCities(bool isSafe);
        Task<IList<City>> GetCities();
        Task<City> AddCity(City city);
    }
}