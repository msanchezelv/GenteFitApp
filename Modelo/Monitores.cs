using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFitApp.Modelo
{
    internal class Monitores
    {
        public int idMonitor { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Nullable<int> idActividad { get; set; }
    }
}
