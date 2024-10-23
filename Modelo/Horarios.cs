using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFitApp.Modelo
{
    internal class Horarios
    {
        public int idHorario { get; set; }
        public string diaSemana { get; set; }
        public System.TimeSpan horaInicio { get; set; }
        public System.TimeSpan horaFin { get; set; }
        public Nullable<int> idActividad { get; set; }

        public virtual Actividad Actividad { get; set; }
        public virtual ICollection<ListaEspera> ListaEspera { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
