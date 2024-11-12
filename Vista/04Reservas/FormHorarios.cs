using GenteFitApp.Modelo;
using GenteFitApp.Modelo.GenteFitApp.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenteFitApp.Vista._06Horarios
{
    public partial class FormHorarios : Form
    {
        public FormHorarios()
        {
            InitializeComponent();
        }


        private void FormHorarios_Resize(object sender, EventArgs e)
        {
            dataGridViewHorarios.AutoResizeColumns();
        }

        private void FormHorarios_Load(object sender, EventArgs e)
        {
            List<HorarioDTO> horarios = HorarioDTO.ObtenerHorariosConActividadYMonitor();
            var horariosAgrupados = horarios.GroupBy(h => h.DiaSemana).ToList();

            foreach (var grupo in horariosAgrupados)
            {
                string diaSemana = grupo.Key;
                TabPage tabPage = null;
                switch (diaSemana.ToLower())
                {
                    case "lunes":
                        tabPage = tabPageLunes;
                        break;
                    case "martes":
                        tabPage = tabPageMartes;
                        break;
                    case "miércoles":
                        tabPage = tabPageMiercoles;
                        break;
                    case "jueves":
                        tabPage = tabPageJueves;
                        break;
                    case "viernes":
                        tabPage = tabPageViernes;
                        break;
                    case "sábado":
                        tabPage = tabPageSabado;
                        break;
                    case "domingo":
                        tabPage = tabPageDomingo;
                        break;
                    default:
                        break;
                }

                if (tabPage != null)
                {
                    DataGridView dataGridViewDia = new DataGridView
                    {
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, // Asegura que las columnas se adapten al tamaño de la ventana
                        AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                        Dock = DockStyle.Fill,
                        BackgroundColor = Color.Bisque,
                        AllowUserToAddRows = false, // Elimina la fila en blanco
                        ReadOnly = true // Hace que el DataGridView sea solo de lectura
                    };

                    BindingList<HorarioDTO> bindingHorariosDia = new BindingList<HorarioDTO>(grupo.ToList());
                    dataGridViewDia.DataSource = bindingHorariosDia;

                    dataGridViewDia.DataBindingComplete += (s, ev) =>
                    {
                        // Configurar encabezados de columnas
                        if (dataGridViewDia.Columns.Contains("Hora"))
                            dataGridViewDia.Columns["Hora"].HeaderText = "Hora";
                        if (dataGridViewDia.Columns.Contains("Actividad"))
                            dataGridViewDia.Columns["Actividad"].HeaderText = "Actividad";
                        if (dataGridViewDia.Columns.Contains("Sala"))
                            dataGridViewDia.Columns["Sala"].HeaderText = "Sala";
                        if (dataGridViewDia.Columns.Contains("Monitor"))
                            dataGridViewDia.Columns["Monitor"].HeaderText = "Monitor";
                        if (dataGridViewDia.Columns.Contains("Plazas"))
                            dataGridViewDia.Columns["Plazas"].HeaderText = "Plazas disponibles";

                        // Ocultar la columna "DiaSemana"
                        if (dataGridViewDia.Columns.Contains("DiaSemana"))
                        {
                            dataGridViewDia.Columns["DiaSemana"].Visible = false;
                        }

                        // Formato de la columna "Hora"
                        dataGridViewDia.Columns["Hora"].DefaultCellStyle.Format = "HH:mm";

                        // Ocultar la columna "Sala" si no es necesario
                        dataGridViewDia.Columns["Sala"].Visible = false;
                    };

                    tabPage.Controls.Add(dataGridViewDia);
                }
            }
        }


    }

}
