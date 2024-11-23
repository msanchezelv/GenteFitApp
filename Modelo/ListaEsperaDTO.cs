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

    public static List<ListaEsperaDTO> ObtenerListaEsperaPorCliente(int idCliente)
    {
        List<ListaEsperaDTO> listaEspera = new List<ListaEsperaDTO>();

        using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            connection.Open();

            using (var command = new SqlCommand("dbo.ConsultarListaEspera", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCliente", idCliente);

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

                        // Imprimir los datos por consola para verificar
                        Console.WriteLine($"IdListaEspera: {item.IdListaEspera}, " +
                                          $"IdHorario: {item.IdHorario}, " +
                                          $"Día: {item.Dia}, " +
                                          $"Hora: {item.Hora}, " +
                                          $"Actividad: {item.Actividad}, " +
                                          $"Sala: {item.Sala}, " +
                                          $"Monitor: {item.Monitor}, " +
                                          $"Plazas: {item.Plazas}, " +
                                          $"Posición: {item.Posicion}, " +
                                          $"Fecha: {item.Fecha}");

                        listaEspera.Add(item);
                    }
                }
            }
        }

        return listaEspera;
    }

}
