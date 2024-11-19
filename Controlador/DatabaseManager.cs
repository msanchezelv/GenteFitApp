using GenteFitApp.Controlador;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GenteFit.Controlador
{
    public class DatabaseManager<T> where T : class, new()
    {
        private readonly string connectionString = DatabaseConfig.ConnectionString;

        public DatabaseManager(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        // Método para obtener todos los registros de la entidad
        public List<T> GetAll()
        {
            List<T> items = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM {typeof(T).Name}";
                Console.WriteLine(query);

                using (SqlCommand command = new SqlCommand(query, connection))

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        T item = new T();

                        foreach (var prop in typeof(T).GetProperties())
                        {
                            try
                            {
                                var ordinal = reader.GetOrdinal(prop.Name);
                                if (ordinal >= 0 && !reader.IsDBNull(ordinal))
                                {
                                    var value = reader.GetValue(ordinal);

                                    if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                    {
                                        prop.SetValue(item, value == DBNull.Value ? null : Convert.ChangeType(value, Nullable.GetUnderlyingType(prop.PropertyType)));
                                    }
                                    else
                                    {
                                        prop.SetValue(item, Convert.ChangeType(value, prop.PropertyType));
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error al intentar acceder a la propiedad {prop.Name}: {ex.Message}");
                                Console.WriteLine($"Valor de la propiedad: {prop.Name}, Tipo: {prop.PropertyType}");
                            }
                        }

                        items.Add(item);
                    }
                }

            }


            return items;
        }

        // Método para obtener un registro por ID
        public T GetById(int id)
        {
            T item = new T();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM {typeof(T).Name} WHERE Id = @id"; // Se asume que el campo clave primaria es "Id"

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            foreach (var prop in typeof(T).GetProperties())
                            {
                                if (!reader.IsDBNull(reader.GetOrdinal(prop.Name)))
                                {
                                    prop.SetValue(item, reader[prop.Name]);
                                }
                            }
                        }
                    }
                }
            }

            return item;
        }

        // Método para insertar un nuevo registro
        public bool Insert(T item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var properties = typeof(T).GetProperties().Where(p => p.Name != "Id").ToList();

                var columnNames = string.Join(", ", properties.Select(p => p.Name));
                var parameterNames = string.Join(", ", properties.Select(p => "@" + p.Name));

                string query = $"INSERT INTO {typeof(T).Name} ({columnNames}) VALUES ({parameterNames})";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    foreach (var prop in properties)
                    {
                        command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(item) ?? DBNull.Value);
                    }

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Método para actualizar un registro existente
        public bool Update(int id, T item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var properties = typeof(T).GetProperties().Where(p => p.Name != "Id").ToList();

                var updateStatements = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));
                string query = $"UPDATE {typeof(T).Name} SET {updateStatements} WHERE Id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    foreach (var prop in properties)
                    {
                        command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(item) ?? DBNull.Value);
                    }

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Método para eliminar un registro
        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"DELETE FROM {typeof(T).Name} WHERE Id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
