using System;
using System.Text;
using System.Text.Json;
using EspacioHistorial;

namespace EspacioHistorialJson
{
    public class HistorialJson
    {
        private List<Historial>? listaGanadores;
        public void GuardarGanador(Historial ganador, string nombreArchivo)
        {
            listaGanadores.Add(ganador);
            listaGanadores.OrderBy(p => p.Daniototal);

            var opciones = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string personajesJson = JsonSerializer.Serialize(listaGanadores, opciones);
            using (FileStream abrir = new(nombreArchivo, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter escribir = new(abrir, Encoding.UTF8))
                {
                    escribir.WriteLine(personajesJson);
                }
            };
        }
    }
}