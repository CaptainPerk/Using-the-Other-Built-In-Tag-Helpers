using System.Collections.Generic;

namespace Cities.Models.Interfaces
{
    public interface ICityRepository
    {
        IEnumerable<City> Cities { get; }
        void AddCity(City newCity);
    }
}
