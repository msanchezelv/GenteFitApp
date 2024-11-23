using GenteFitApp.Controlador;
using GenteFitApp.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace GenteFitApp.Vista._05ListaEspera
{
    public partial class ListaEspera : Form
    {
        public ListaEspera()
        {
            InitializeComponent();
        }

        private void ListaEspera_Load(object sender, EventArgs e)
        {
            int idCliente = ControladorInicioSesion.IdClienteActual;
            List<ListaEsperaDTO> listaEspera = ListaEsperaDTO.ObtenerListaEsperaPorCliente(idCliente != -1 ? (int?)idCliente : null);

            //listaEspera = listaEspera.Where(le =>
            //        DateTime.Parse(le.Fecha) > DateTime.Now ||
            //        (DateTime.Parse(le.Fecha) == DateTime.Now.Date &&
            //         TryParseHora(le.Hora.Split('-')[0], out TimeSpan hora) && hora >= DateTime.Now.TimeOfDay)
            //    ).ToList();

            listaEspera = listaEspera.OrderBy(le => DateTime.Parse(le.Fecha))
                                     .ThenBy(le => TryParseHora(le.Hora.Split('-')[0], out TimeSpan hora) ? hora : TimeSpan.Zero)
                                     .ToList();

            BindingList<ListaEsperaDTO> bindingListaEspera = new BindingList<ListaEsperaDTO>(listaEspera);
            dataGridViewListaEspera.DataSource = bindingListaEspera;

            if (dataGridViewListaEspera.Columns.Contains("IdListaEspera"))
            {
                dataGridViewListaEspera.Columns["IdListaEspera"].Visible = false;
            }

            if (dataGridViewListaEspera.Columns.Contains("Cliente"))
            {
                dataGridViewListaEspera.Columns["Cliente"].Visible = ControladorInicioSesion.RolUsuarioActual != "Cliente";
                // Colocar la columna Cliente en la segunda o tercera posición
                
            }

            if (dataGridViewListaEspera.Columns.Contains("IdHorario"))
            {
                dataGridViewListaEspera.Columns["IdHorario"].Visible = false;
            }

            if (dataGridViewListaEspera.Columns.Contains("Plazas"))
            {
                dataGridViewListaEspera.Columns["Plazas"].Visible = false;
            }


            dataGridViewListaEspera.Columns["Fecha"].HeaderText = "Fecha";
            dataGridViewListaEspera.Columns["Dia"].HeaderText = "Día";
            dataGridViewListaEspera.Columns["Actividad"].HeaderText = "Actividad";
            dataGridViewListaEspera.Columns["Hora"].HeaderText = "Hora";
            dataGridViewListaEspera.Columns["Monitor"].HeaderText = "Monitor";
            dataGridViewListaEspera.Columns["Posicion"].HeaderText = "Posición";
            dataGridViewListaEspera.Columns["Cliente"].HeaderText = "Cliente";

            dataGridViewListaEspera.Columns["Actividad"].DisplayIndex = 0;
            dataGridViewListaEspera.Columns["Cliente"].DisplayIndex = 1;
            dataGridViewListaEspera.Columns["Sala"].DisplayIndex = 2;
            dataGridViewListaEspera.Columns["Monitor"].DisplayIndex = 3;
            dataGridViewListaEspera.Columns["Fecha"].DisplayIndex = 4;
            dataGridViewListaEspera.Columns["Dia"].DisplayIndex = 5;
            dataGridViewListaEspera.Columns["Hora"].DisplayIndex = 6;
            dataGridViewListaEspera.Columns["Posicion"].DisplayIndex = 7;

            foreach (DataGridViewColumn column in dataGridViewListaEspera.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            dataGridViewListaEspera.Refresh();
        }


        private bool TryParseHora(string hora, out TimeSpan time)
        {
            Debug.WriteLine($"Intentando parsear hora: {hora}");
            return TimeSpan.TryParse(hora.Trim(), out time);  // Usamos Trim() para eliminar posibles espacios
        }


    }
}
