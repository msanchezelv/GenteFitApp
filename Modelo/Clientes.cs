using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFitApp.Modelo
{
    internal class Clientes
    {
        public int idCliente { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public Nullable<int> idUsuario { get; set; }
    }
}
