using Pruebas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas.Services
{
    class ServiceGetAllCityInLocalData
    {

        public List<List<Root>> _allCity { get; } = new List<List<Root>> ();

        public void AddCity(List<Root> city)
        {
            _allCity.Add (city);
        }

    }
}
