using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFitApp.Modelo
{
    internal class ListasEspera
    {
        public int idListaEspera { get; set; }
        public Nullable<int> idActividad { get; set; }
        public Nullable<int> idHorario { get; set; }
        public Nullable<int> idCliente { get; set; }
        public Nullable<int> posicion { get; set; }
    
        public virtual Actividad Actividad { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Horario Horario { get; set; }
    }
}
