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
    using System.Data.SqlClient;
    
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.Cliente = new HashSet<Cliente>();
        }
    
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }
        public string rol { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Cliente { get; set; }

        public Usuario ObtenerUsuario(int idUsuario, string contraseña)
            {
                Usuario usuario = null;
                string connectionString = @"Data Source=DESKTOP-1JIM32R\SQLEXPRESS;Initial Catalog=GenteFit;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Consulta SQL para obtener el usuario por idUsuario y contraseña
                    string query = "SELECT idUsuario, nombre, apellido, email, rol FROM Usuario WHERE idUsuario = @IdUsuario AND contraseña = @Contraseña";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar parámetros para evitar inyecciones SQL
                        command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                        command.Parameters.AddWithValue("@Contraseña", contraseña);

                        // Abrir la conexión a la base de datos
                        connection.Open();

                        // Ejecutar el lector de datos
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Crear un objeto Usuario a partir de los datos obtenidos
                                usuario = new Usuario
                                {
                                    idUsuario = (int)reader["idUsuario"],
                                    nombre = reader["nombre"].ToString(),
                                    apellido = reader["apellido"].ToString(),
                                    email = reader["email"].ToString(),
                                    contraseña = contraseña,
                                    rol = reader["rol"].ToString()
                                };
                            }
                        }
                    }
                }
                return usuario; // Retorna el objeto Usuario o null si no se encontró
            }
            
            public static implicit operator Usuario(string v)
            {
            throw new NotImplementedException();
            }
            }
}
