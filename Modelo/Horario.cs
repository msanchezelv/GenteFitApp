//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GenteFitApp.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Horario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Horario()
        {
            this.ListaEspera = new HashSet<ListaEspera>();
            this.Reserva = new HashSet<Reserva>();
        }
    
        public int idHorario { get; set; }
        public string diaSemana { get; set; }
        public System.TimeSpan horaInicio { get; set; }
        public System.TimeSpan horaFin { get; set; }
        public Nullable<int> idActividad { get; set; }
        public Nullable<int> sala { get; set; }
        public string Monitor { get; set; }
        public Nullable<int> duracion { get; set; }
    
        public virtual Actividad Actividad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListaEspera> ListaEspera { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
