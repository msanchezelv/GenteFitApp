using GenteFitApp.Controlador;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

public class ReservaDTO
{
    public int IdReserva { get; set; }
    public string FechaReserva { get; set; }
    public string Cliente { get; set; }
    public string Actividad { get; set; }
    public string Hora { get; set; }
    public string Duracion { get; set; }
    public string FechaCompleta { get; set; }

    public static List<ReservaDTO> ObtenerReservasPorCliente(int? idCliente)
    {
        List<ReservaDTO> reservas = new List<ReservaDTO>();
        string connectionString = DatabaseConfig.ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("dbo.ConsultarReservas", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                if (idCliente.HasValue)
                {
                    command.Parameters.AddWithValue("@idCliente", idCliente.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@idCliente", DBNull.Value);
                }

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReservaDTO reserva = new ReservaDTO
                        {
                            IdReserva = reader["idReserva"] != DBNull.Value ? Convert.ToInt32(reader["idReserva"]) : 0,
                            FechaReserva = reader["fechaReserva"] != DBNull.Value ? reader["fechaReserva"].ToString() : string.Empty,
                            Cliente = reader["Cliente"] != DBNull.Value ? reader["Cliente"].ToString() : string.Empty,
                            Actividad = reader["Actividad"] != DBNull.Value ? reader["Actividad"].ToString() : string.Empty,
                            FechaCompleta = reader["FechaCompleta"] != DBNull.Value ? reader["FechaCompleta"].ToString() : string.Empty,
                            Hora = reader["Hora"] != DBNull.Value ? reader["Hora"].ToString() : string.Empty,
                            Duracion = reader["Duracion"] != DBNull.Value ? reader["Duracion"].ToString() : string.Empty
                        };

                        reservas.Add(reserva);
                    }
                }
            }
        }

        return reservas;
    }
}
