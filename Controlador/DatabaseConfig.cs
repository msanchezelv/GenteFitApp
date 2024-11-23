using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFitApp.Controlador
{
    public static class DatabaseConfig
    {
        public static string ConnectionString { get; } = "Data Source=MiniDELL;Initial Catalog=GenteFit;Integrated Security=True";
    }
}
