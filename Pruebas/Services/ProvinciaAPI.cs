using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas.Services
{
    class ProvinciaAPI
    {

        private HttpClient client = new();

        public ProvinciaAPI()
        {

        }

        public void GetProvincias()
        {
            string ruta = "https://api.weatherapi.com/v1/forecast.json?q=";
            string rut = "https";
            var busquedaProvincias = client.GetAsync("");
        }

    }
}
