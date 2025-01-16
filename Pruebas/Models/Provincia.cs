using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas.Models
{
    class Provincia
    {
        string nombre { get; set; }
        decimal latitud { get; set; }
        decimal longitud { get; set; }
        decimal temperatura { get; set; }

        public Provincia() { }

        public Provincia(string nombre, decimal latitud, decimal longitud, decimal temperatura)
        {
            this.nombre = nombre;
            this.latitud = latitud;
            this.longitud = longitud;
            this.temperatura = temperatura;
        }
    }
}
