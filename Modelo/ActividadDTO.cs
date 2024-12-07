namespace GenteFitApp.Modelo
{
    public class ActividadDTO
    {
        public int IdActividad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string NivelIntensidad { get; set; }
        public int? Sala { get; set; }
        public int? PlazasDisponibles { get; set; }
        public int? IdMonitor { get; set; }

        // Constructor
        public ActividadDTO(int idActividad, string nombre, string descripcion, string nivelIntensidad, int? sala, int? plazasDisponibles, int? idMonitor)
        {
            IdActividad = idActividad;
            Nombre = nombre;
            Descripcion = descripcion;
            NivelIntensidad = nivelIntensidad;
            Sala = sala;
            PlazasDisponibles = plazasDisponibles;
            IdMonitor = idMonitor;
        }

        // Método estático para mapear desde Actividad a ActividadDTO
        public static ActividadDTO FromActividad(Actividad actividad)
        {
            return new ActividadDTO(
                actividad.idActividad,
                actividad.nombre,
                actividad.descripcion,
                actividad.nivelIntensidad,
                actividad.sala,
                actividad.plazasDisponibles,
                actividad.idMonitor
            );
        }
    }
}
