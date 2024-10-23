using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFitApp.Modelo
{
    internal class Reservas
    {
        public int idReserva { get; set; }
        public Nullable<int> idCliente { get; set; }
        public Nullable<int> idHorario { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Horario Horario { get; set; }
    }
}
