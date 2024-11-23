using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;

namespace GenteFitApp.Vista
{
    public partial class AgregarActividades : FormularioBase
    {

        public AgregarActividades()
        {
            InitializeComponent(); 
            this.Load += new EventHandler(AgregarActividades_Load); 
            this.comboBoxMonitor.SelectedIndexChanged += new EventHandler(comboBoxMonitor_SelectedIndexChanged); 
            this.comboBoxSala.SelectedIndexChanged += new EventHandler(comboBoxSala_SelectedIndexChanged); 
            this.textBoxIdActividad.TextChanged += new EventHandler(textBoxIdActividad_TextChanged); 
            this.buttonCargar.Click += new EventHandler(buttonCargar_Click); 
            this.ButtonEliminarActividad.Click += new EventHandler(buttonEliminarActividad_Click); 
            this.buttonModificar.Click += new EventHandler(buttonModificar_Click);
        }


        // Métodos que se cargan al abrirse la ventana
        private void AgregarActividades_Load(object sender, EventArgs e)
        {
            GenerarCodigoActividad();
            CargarDatosActividades();
            CargarMonitores();
        }

        SqlConnection con = new SqlConnection("Data Source=MiniDELL; Initial Catalog=GenteFit; Integrated Security=True");

        private void groupBoxClientes_Enter(object sender, EventArgs e)
        {

        }

        private void label_IdUsuario_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxcontraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonUpdateActividad_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            string nombre = textBoxNombreActividad.Text;
            string descripcion = textBoxDescripcion.Text;
            string nivelIntensidad = comboBoxNivel.SelectedItem.ToString();
            int sala = int.Parse(comboBoxSala.SelectedItem.ToString());
            int plazasDisponibles = int.Parse(textBoxPlazasDisponibles.Text);
            int idMonitor = int.Parse(comboBoxMonitor.SelectedValue.ToString());
            int idSala = int.Parse(textBoxIdSala.Text);

            InsertarActividad(nombre, descripcion, nivelIntensidad, sala, plazasDisponibles, idMonitor, idSala);

            RestablecerFormulario();
            CargarDatosActividades();
        }


        private void comboBoxNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxNivel.Items.Add("BAJO");
            comboBoxNivel.Items.Add("MEDIO");
            comboBoxNivel.Items.Add("ALTO");
        }

        private void comboBoxSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSala.Items.Add("1");
            comboBoxSala.Items.Add("2");
            comboBoxSala.Items.Add("3");
            comboBoxSala.Items.Add("4");

            if (comboBoxSala.SelectedItem != null) 
            { 
                textBoxIdSala.Text = comboBoxSala.SelectedItem.ToString(); 
            }
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            // Código para abrir la ventana GestionActividades
            PrincipalAdmin principalAdmin = new PrincipalAdmin();
            principalAdmin.Show(); // Abre la nueva ventana
            this.Hide(); // Oculta la ventana actual (opcional)
        }

        private void textBoxDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNombreActividad_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxIdActividad_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxIdActividad.Text, out int idActividad))
            {
                if (ExisteIdActividad(idActividad))
                {
                    textBoxIdActividad.BackColor = SystemColors.Window;
                }
                else
                {
                    textBoxIdActividad.BackColor = Color.LightCoral;
                }
            }
            else
            {
                textBoxIdActividad.BackColor = Color.LightCoral;
            }
        }

        private void comboBoxMonitor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMonitor.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)comboBoxMonitor.SelectedItem;
                int idMonitor = (int)selectedRow["idMonitor"];
                textBoxIdMonitor.Text = idMonitor.ToString();
            }
        }

        private void dataGridViewActividades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonEliminarActividad_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que quiere eliminar esta actividad?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (int.TryParse(textBoxIdActividad.Text, out int idActividad))
                {
                    EliminarActividad(idActividad);
                    MessageBox.Show("La actividad se ha eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RestablecerFormulario();
                    CargarDatosActividades();
                }
                else
                {
                    MessageBox.Show("Por favor, introduzca un ID de actividad válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void textBoxIdMonitor_TextChanged(object sender, EventArgs e)
        {

        }


        private void buttonCargar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxIdActividad.Text, out int idActividad) && ExisteIdActividad(idActividad))
            {
                CargarActividad(idActividad);
            }
            else
            {
                MessageBox.Show("Por favor, introduzca un ID de actividad válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que quiere modificar esta actividad?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (int.TryParse(textBoxIdActividad.Text, out int idActividad))
                {
                    ModificarActividad(idActividad);
                    MessageBox.Show("La actividad se ha modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RestablecerFormulario();
                    CargarDatosActividades();
                }
                else
                {
                    MessageBox.Show("Por favor, introduzca un ID de actividad válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void textBoxActividad_TextChanged(object sender, EventArgs e)
        {   // Modificamos aspecto
            if (string.IsNullOrEmpty(textBoxIdActividad.Text))
            {
                textBoxIdActividad.BackColor = SystemColors.Window;
            }
            else
            {
                textBoxIdActividad.BackColor = Color.WhiteSmoke;
            }
        }




        // Método para generar el nuevo código de actividad basado en el idActividad
        private string GenerarNuevoCodigoActividad()
        {
            int proximoId = ObtenerProximoIdActividad();
            return proximoId.ToString();
        }

        //Método para generar el código de actividad y actualizar el textBoxActividad
        private void GenerarCodigoActividad()
        {
            string nuevoCodigo = GenerarNuevoCodigoActividad();
            textBoxIdActividad.Text = nuevoCodigo;
            textBoxIdActividad.BackColor = Color.Gray;
        }

        // Método para obtener el próximo idActividad
        private int ObtenerProximoIdActividad()
        {
            string connectionString = "Data Source=MiniDELL;Initial Catalog=GenteFit;Integrated Security=True";
            int proximoId = 1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ISNULL(MAX(idActividad), 0) + 1 FROM Actividad";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    proximoId = Convert.ToInt32(result);
                }
            }

            return proximoId;
        }

        // Método para cargar actividad
        private void CargarActividad(int idActividad)
        {
            string connectionString = "Data Source=MiniDELL;Initial Catalog=GenteFit;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Actividad WHERE idActividad = @idActividad";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idActividad", idActividad);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBoxNombreActividad.Text = reader["nombre"].ToString();
                        textBoxDescripcion.Text = reader["descripcion"].ToString();
                        comboBoxNivel.SelectedItem = reader["nivelIntensidad"].ToString();
                        comboBoxSala.SelectedItem = reader["sala"].ToString();
                        textBoxPlazasDisponibles.Text = reader["plazasDisponibles"].ToString();
                        textBoxIdMonitor.Text = reader["idMonitor"].ToString();
                        textBoxIdSala.Text = reader["idSala"].ToString();
                    }
                }
            }
        }

        // Método para eliminar una actividad
        private void EliminarActividad(int idActividad)
        {
            string conString = "Data Source=MiniDELL;Initial Catalog=GenteFit;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "DELETE FROM Actividad WHERE idActividad = @idActividad";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@idActividad", idActividad);

                con.Open();
                command.ExecuteNonQuery();
            }

            CargarDatosActividades();
        }

        // Método para modiciar actividad
        private void ModificarActividad(int idActividad)
        {
            string nombre = textBoxNombreActividad.Text;
            string descripcion = textBoxDescripcion.Text;
            string nivelIntensidad = comboBoxNivel.SelectedItem.ToString();
            int sala = int.Parse(comboBoxSala.SelectedItem.ToString());
            int plazasDisponibles = int.Parse(textBoxPlazasDisponibles.Text);
            int idMonitor = int.Parse(comboBoxMonitor.SelectedValue.ToString());
            int idSala = int.Parse(textBoxIdSala.Text);

            string connectionString = "Data Source=MiniDELL;Initial Catalog=GenteFit;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Actividad SET nombre = @nombre, descripcion = @descripcion, nivelIntensidad = @nivelIntensidad, sala = @sala, plazasDisponibles = @plazasDisponibles, idMonitor = @idMonitor, idSala = @idSala WHERE idActividad = @idActividad";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@nivelIntensidad", nivelIntensidad);
                command.Parameters.AddWithValue("@sala", sala);
                command.Parameters.AddWithValue("@plazasDisponibles", plazasDisponibles);
                command.Parameters.AddWithValue("@idMonitor", idMonitor);
                command.Parameters.AddWithValue("@idSala", idSala);
                command.Parameters.AddWithValue("@idActividad", idActividad);

                connection.Open();
                command.ExecuteNonQuery();
            }

            CargarDatosActividades();
        }

        // Método para cargar los datos de Actividades en la BBDD
        private void CargarDatosActividades()
        {
            string conString = "Data Source=MiniDELL;Initial Catalog=GenteFit;Integrated Security=True";
            string query = "SELECT * FROM Actividad";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridViewActividades.DataSource = dataTable;

                // Ajustar el ancho de las columnas automáticamente
                dataGridViewActividades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Ajustar el estilo de las celdas y el encabezado
                dataGridViewActividades.DefaultCellStyle.Font = new Font("Arial", 8);
                dataGridViewActividades.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
                dataGridViewActividades.DefaultCellStyle.Padding = new Padding(2);
                dataGridViewActividades.ColumnHeadersDefaultCellStyle.Padding = new Padding(2);

                // Ajustar el alto de las filas
                dataGridViewActividades.RowTemplate.Height = 22;
            }
        }

        // Método para Validar los campos al darle a cargar
        private bool ValidarCampos()
        {
            bool camposCompletos = true;

            // Resetea los bordes de los controles a su color original
            ResetBorders();

            if (string.IsNullOrWhiteSpace(textBoxNombreActividad.Text))
            {
                textBoxNombreActividad.BorderStyle = BorderStyle.FixedSingle;
                textBoxNombreActividad.BackColor = Color.LightCoral;
                camposCompletos = false;
            }

            if (string.IsNullOrWhiteSpace(textBoxDescripcion.Text))
            {
                textBoxDescripcion.BorderStyle = BorderStyle.FixedSingle;
                textBoxDescripcion.BackColor = Color.LightCoral;
                camposCompletos = false;
            }

            if (comboBoxNivel.SelectedIndex == -1)
            {
                comboBoxNivel.BackColor = Color.LightCoral;
                camposCompletos = false;
            }

            if (comboBoxSala.SelectedIndex == -1)
            {
                comboBoxSala.BackColor = Color.LightCoral;
                camposCompletos = false;
            }

            if (string.IsNullOrWhiteSpace(textBoxPlazasDisponibles.Text))
            {
                textBoxPlazasDisponibles.BorderStyle = BorderStyle.FixedSingle;
                textBoxPlazasDisponibles.BackColor = Color.LightCoral;
                camposCompletos = false;
            }

            if (string.IsNullOrWhiteSpace(textBoxIdMonitor.Text))
            {
                textBoxIdMonitor.BorderStyle = BorderStyle.FixedSingle;
                textBoxIdMonitor.BackColor = Color.LightCoral;
                camposCompletos = false;
            }

            if (string.IsNullOrWhiteSpace(textBoxIdSala.Text))
            {
                textBoxIdSala.BorderStyle = BorderStyle.FixedSingle;
                textBoxIdSala.BackColor = Color.LightCoral;
                camposCompletos = false;
            }

            if (!camposCompletos)
            {
                MessageBox.Show("Debe rellenar todos los campos", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return camposCompletos;
        }

        private void ResetBorders()
        {
            textBoxNombreActividad.BorderStyle = BorderStyle.Fixed3D;
            textBoxNombreActividad.BackColor = SystemColors.Window;

            textBoxDescripcion.BorderStyle = BorderStyle.Fixed3D;
            textBoxDescripcion.BackColor = SystemColors.Window;

            comboBoxNivel.BackColor = SystemColors.Window;
            comboBoxSala.BackColor = SystemColors.Window;

            textBoxPlazasDisponibles.BorderStyle = BorderStyle.Fixed3D;
            textBoxPlazasDisponibles.BackColor = SystemColors.Window;

            textBoxIdMonitor.BorderStyle = BorderStyle.Fixed3D;
            textBoxIdMonitor.BackColor = SystemColors.Window;

            textBoxIdSala.BorderStyle = BorderStyle.Fixed3D;
            textBoxIdSala.BackColor = SystemColors.Window;
        }


        // Método para Insertar la Actividad en la Base de Dato
        private void InsertarActividad(string nombre, string descripcion, string nivelIntensidad, int sala, int plazasDisponibles, int idMonitor, int idSala)
        {
            string conString = "Data Source=MiniDELL;Initial Catalog=GenteFit;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "INSERT INTO Actividad (nombre, descripcion, nivelIntensidad, sala, plazasDisponibles, idMonitor, idSala) " +
                               "VALUES (@nombre, @descripcion, @nivelIntensidad, @sala, @plazasDisponibles, @idMonitor, @idSala)";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@descripcion", descripcion);
                    command.Parameters.AddWithValue("@nivelIntensidad", nivelIntensidad);
                    command.Parameters.AddWithValue("@sala", sala);
                    command.Parameters.AddWithValue("@plazasDisponibles", plazasDisponibles);
                    command.Parameters.AddWithValue("@idMonitor", idMonitor);
                    command.Parameters.AddWithValue("@idSala", idSala);

                    con.Open();
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Actividad agregada correctamente.");
            CargarDatosActividades();
        }

        // Método para Cargar Monitores
        private void CargarMonitores()
        {
            string conString = "Data Source=MiniDELL;Initial Catalog=GenteFit;Integrated Security=True";
            string query = "SELECT idMonitor, nombre + ' ' + apellidos AS NombreCompleto FROM Monitor ORDER BY idMonitor";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                comboBoxMonitor.DataSource = dataTable;
                comboBoxMonitor.DisplayMember = "NombreCompleto";
                comboBoxMonitor.ValueMember = "idMonitor";
            }
        }

        // Método para Restablecer el Formulario
        private void RestablecerFormulario()
        {
            textBoxNombreActividad.Clear();
            textBoxDescripcion.Clear();
            comboBoxNivel.SelectedIndex = -1;
            comboBoxSala.SelectedIndex = -1;
            textBoxPlazasDisponibles.Clear();
            textBoxIdMonitor.Clear();
            textBoxIdSala.Clear();

            // Generar el próximo código de actividad
            GenerarCodigoActividad();
        }

        // Método para comprobar que existe la idActividad introducida
        private bool ExisteIdActividad(int idActividad)
        {
            string conString = "Data Source=MiniDELL;Initial Catalog=GenteFit;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "SELECT COUNT(*) FROM Actividad WHERE idActividad = @idActividad";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@idActividad", idActividad);

                con.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
