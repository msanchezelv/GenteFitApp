using GenteFitApp.Modelo;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class OdooConnector
{
    private readonly string odooUrl = "http://192.168.1.160:8069";  // URL de tu endpoint

    public async Task CrearActividadEnOdoo(Actividad actividad)
    {
        using (HttpClient client = new HttpClient())
        {
            var actividadData = new
            {
                actividad = new
                {
                    idActividad = actividad.idActividad,
                    nombre = actividad.nombre,
                    descripcion = actividad.descripcion,
                    nivelIntensidad = actividad.nivelIntensidad,
                    salas = actividad.sala,
                    plazasDisponibles = actividad.plazasDisponibles,
                    idMonitor = actividad.idMonitor
                }
            };

            string jsonContent = JsonConvert.SerializeObject(actividadData);
            StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(odooUrl, content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Actividad creada en Odoo.");
            }
            else
            {
                Console.WriteLine("Error al crear la actividad en Odoo.");
            }
        }
    }
}