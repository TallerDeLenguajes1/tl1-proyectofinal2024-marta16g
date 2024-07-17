using System.Text.Json;
using EspacioPersonaje;
using EspacioCaracteristica;

namespace EspacioPersonajesJS
{
    public class PersonajesJson
    {
        public void GuardarPersonajes(List<Personaje> listaPersonajes, string nombreArchivo)
        {
            string personajesJson = JsonSerializer.Serialize(listaPersonajes);
            using (FileStream abrir = new(nombreArchivo,  FileMode.OpenOrCreate))
            {
                using (StreamWriter escribir = new(abrir))
                {
                    escribir.WriteLine(personajesJson);
                }
            };

        }

        public List<Personaje>? LeerPersonajes(string nombreArchivo)
        {
            string archivoJson;
            using(FileStream abrir = new(nombreArchivo, FileMode.Open))
            {
                using (StreamReader leer = new(abrir))
                {
                    archivoJson = leer.ReadToEnd();
                }
            }

            var opciones = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var listaPersonajesLeidos = JsonSerializer.Deserialize<List<Personaje>>(archivoJson, opciones);
            if (listaPersonajesLeidos != null)
                        {
                            foreach (var personaje in listaPersonajesLeidos)
                            {
                                if (personaje.Caracteristica == null)
                                {
                                    personaje.Caracteristica = new Caracteristica();
                                }
                            }
                        }
            return listaPersonajesLeidos; 
        }
    }
}