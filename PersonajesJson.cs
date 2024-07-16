using System.Text.Json;
using EspacioPersonaje;

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
                    escribir.Close();
                }
            };

        }

        public List<Personaje> LeerPersonajes(string nombreArchivo)
        {
            string archivoJson;
            using(FileStream abrir = new(nombreArchivo, FileMode.Open))
            {
                using (StreamReader leer = new(abrir))
                {
                    archivoJson = leer.ReadToEnd();
                    leer.Close();
                }
            }

            var ListaPersonajesLeidos = JsonSerializer.Deserialize<List<Personaje>>(archivoJson); 
        }
    }
}