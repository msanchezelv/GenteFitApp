using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFitApp.Controlador
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Reserva
    {
        private string connectionString = "Server=DESKTOP-1JIM32R\\SQLEXPRESS;Database=GenteFit;Integrated Security=True;";

        public void ReservarClase(int idCliente, int idHorario)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Crear el comando para ejecutar la stored procedure
                    SqlCommand cmd = new SqlCommand("ReservarClase", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros para la stored procedure
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    cmd.Parameters.AddWithValue("@idHorario", idHorario);

                    // Ejecutar la stored procedure
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Reserva realizada con éxito.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrió un error al realizar la reserva: " + ex.Message);
                }
            }
        }
    }

}
