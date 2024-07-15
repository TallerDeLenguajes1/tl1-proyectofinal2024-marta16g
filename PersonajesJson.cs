using System.Text.Json;
using EspacioPersonaje;

namespace EspacioPersonajesJS
{
    public class PersonajesJson
    {
        public void GuardarPersonajes(List<Personaje> listaPersonajes, string nombreArchivo)
        {
            string personajesJson = JsonSerializer.Serialize(listaPersonajes);
            using (FileStream abrir = new(nombreArchivo, FileMode.Open))
            {

            };

        }
    }
}