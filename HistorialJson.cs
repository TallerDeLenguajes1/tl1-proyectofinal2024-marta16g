using System;
using System.Text;
using System.Text.Json;
using EspacioHistorial;
using EspacioPersonajesJS;

namespace EspacioHistorialJson
{
    public class HistorialJson
    {
        public void GuardarGanador(Historial ganador, string nombreArchivo)
        {
            List<Historial> listaGanadores = new();

            if (PersonajesJson.ExisteArchivo(nombreArchivo))
            {
                listaGanadores = LeerGanadores(nombreArchivo);
            }
            listaGanadores.Add(ganador);

            var opciones = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string ganadoresJson = JsonSerializer.Serialize(listaGanadores, opciones);
            using (FileStream abrir = new(nombreArchivo, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter escribir = new(abrir, Encoding.UTF8))
                {
                    escribir.WriteLine(ganadoresJson);
                }
            };
        }

        public List<Historial> LeerGanadores(string nombreArchivo)
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

            var listaGanadoresLeidos = JsonSerializer.Deserialize<List<Historial>>(archivoExtraido, opciones) ?? new List<Historial>();
            return listaGanadoresLeidos;
        }
    }
}