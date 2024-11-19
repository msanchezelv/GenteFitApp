using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenteFitApp.Controlador;



namespace GenteFitApp.Modelo
{
    namespace GenteFitApp.Modelo
    {
        
        public class HorarioDTO
        {
            public int idHorario {  get; set; }
            public string DiaSemana { get; set; }
            public string Hora { get; set; }
            public string Actividad { get; set; }
            public int Sala { get; set; }
            public string Monitor { get; set; }
            public int Plazas { get; set; }
            public DateTime Fecha { get; set; }

            public static List<HorarioDTO> ObtenerHorariosConActividadYMonitor(string diaSemana = null)
            {
                List<HorarioDTO> horarios = new List<HorarioDTO>();
                string connectionString = DatabaseConfig.ConnectionString;

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
                                    Plazas = Convert.ToInt32(reader["Plazas"]),
                                    Fecha = Convert.ToDateTime(reader["Fecha"])
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
