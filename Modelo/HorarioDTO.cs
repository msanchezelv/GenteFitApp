using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFitApp.Modelo
{
    namespace GenteFitApp.Modelo
    {
        using System;
        using System.Collections.Generic;
        using System.Data;
        using System.Data.SqlClient;

        public class HorarioDTO
        {
            public int idHorario {  get; set; }
            public string DiaSemana { get; set; }
            public string Hora { get; set; }
            public string Actividad { get; set; }
            public int Sala { get; set; }
            public string Monitor { get; set; }
            public int Plazas { get; set; } // Nueva propiedad para las plazas disponibles

            public static List<HorarioDTO> ObtenerHorariosConActividadYMonitor(string diaSemana = null)
            {
                List<HorarioDTO> horarios = new List<HorarioDTO>();
                string connectionString = "Data Source=DESKTOP-1JIM32R\\SQLEXPRESS;Initial Catalog=GenteFit;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("dbo.ObtenerHorariosConActividadYMonitor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (!string.IsNullOrEmpty(diaSemana))
                        {
                            command.Parameters.AddWithValue("@DiaSemana", diaSemana);
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                HorarioDTO horario = new HorarioDTO
                                {
                                    idHorario = Convert.ToInt32(reader["idHorario"]),
                                    DiaSemana = reader["Día"].ToString(),
                                    Hora = reader["Hora"].ToString(),
                                    Actividad = reader["Actividad"].ToString(),
                                    Sala = Convert.ToInt32(reader["Sala"]),
                                    Monitor = reader["Monitor"].ToString(),
                                    Plazas = Convert.ToInt32(reader["Plazas"])
                                };

                                horarios.Add(horario);
                            }
                        }
                    }
                }

                return horarios;
            }
        }

    }



}
