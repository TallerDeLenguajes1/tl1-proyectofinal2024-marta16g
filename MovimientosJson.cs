using System;
using System.Text.Json;
using EspacioMovimiento;

namespace EspacioMovimientoJson
{
    public class MovimientosJson
    {
        public List<Movimiento>? LeerMovimientos(string nombreArchivo)
        {
            string archivoExtraido;
            using (FileStream abrir = new(nombreArchivo, FileMode.Open))
            {
                using (StreamReader leer = new(abrir))
                {
                    archivoExtraido = leer.ReadToEnd();
                }
            }

            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var listaMovimientosLeidos = JsonSerializer.Deserialize<List<Movimiento>>(archivoExtraido, opciones);

            return listaMovimientosLeidos;
        }
    }
}