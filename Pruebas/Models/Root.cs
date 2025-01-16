using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas.Models
{
    public class Root
    {
        public DateTime date { get; set; }
        public string name { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double maxTemperature { get; set; }
        public double minTemperature { get; set; }
        public double precipitation { get; set; }
        public double wind { get; set; }
        public string image { get; set; }
        public string textImage { get; set; }
    }
}
