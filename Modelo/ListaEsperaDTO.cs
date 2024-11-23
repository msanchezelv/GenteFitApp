using GenteFitApp.Controlador;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Forms;

public class ListaEsperaDTO
{
    public int IdListaEspera { get; set; }
    public int IdHorario { get; set; }
    public string Dia { get; set; }
    public string Hora { get; set; }
    public string Actividad { get; set; }
    public int Sala { get; set; }
    public string Monitor { get; set; }
    public int Plazas { get; set; }
    public int Posicion { get; set; }
    public string Fecha { get; set; }
    public string Cliente { get; set; }  // Nueva propiedad para el nombre del cliente

    public static List<ListaEsperaDTO> ObtenerListaEsperaPorCliente(int? idCliente)
    {
        List<ListaEsperaDTO> listaEspera = new List<ListaEsperaDTO>();

        using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            connection.Open();

            using (var command = new SqlCommand("dbo.ConsultarListaEspera", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Si el idCliente es 0 o no se pasa, el parámetro es nulo
                if (idCliente > 0)
                {
                    command.Parameters.AddWithValue("@idCliente", idCliente);
                }
                else
                {
                    command.Parameters.AddWithValue("@idCliente", DBNull.Value);
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new ListaEsperaDTO
                        {
                            IdListaEspera = reader.GetInt32(reader.GetOrdinal("idListaEspera")),
                            IdHorario = reader.GetInt32(reader.GetOrdinal("idHorario")),
                            Dia = reader.GetString(reader.GetOrdinal("Día")),
                            Hora = reader.GetString(reader.GetOrdinal("Hora")),
                            Actividad = reader.GetString(reader.GetOrdinal("Actividad")),
                            Sala = reader.GetInt32(reader.GetOrdinal("Sala")),
                            Monitor = reader.GetString(reader.GetOrdinal("Monitor")),
                            Plazas = reader.GetInt32(reader.GetOrdinal("Plazas")),
                            Posicion = reader.GetInt32(reader.GetOrdinal("Posicion")),
                            Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")).ToString("dd/MM/yyyy")
                        };

                        if (reader["Cliente"] != DBNull.Value)
                        {
                            item.Cliente = reader.GetString(reader.GetOrdinal("Cliente"));
                        }

                        

                        listaEspera.Add(item);
                    }
                }
            }
        }

        return listaEspera;
    }
}
