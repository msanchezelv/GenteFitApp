using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFitApp.Modelo
{
    internal class Actividades
    {
        public int idActividad { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string nivelIntensidad { get; set; }
        public Nullable<int> sala { get; set; }
        public Nullable<int> plazasDisponibles { get; set; }
        public Nullable<int> idMonitor { get; set; }
        
    }
}
