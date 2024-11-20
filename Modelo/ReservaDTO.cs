using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFitApp.Modelo
{
    public class ReservaDTO
    {
        public int IdReserva { get; set; }
        public string FechaReserva { get; set; }
        public string Cliente { get; set; }
        public string Actividad { get; set; }
        public string Dia { get; set; }
        public string Hora { get; set; }
        public string Duracion { get; set; }
    }

}
