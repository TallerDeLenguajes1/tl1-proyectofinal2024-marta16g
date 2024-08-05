using System.Text;
using System.Text.Json;
using EspacioPersonaje;
using EspacioCaracteristica;

namespace EspacioPersonajesJS
{
    public class PersonajesJson
    {
        public void GuardarPersonajes(List<Personaje> listaPersonajes, string nombreArchivo)
        {
           

            var opciones = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            string personajesJson = JsonSerializer.Serialize(listaPersonajes, opciones);
            using (FileStream abrir = new(nombreArchivo, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter escribir = new(abrir, Encoding.UTF8))
                {
                    escribir.WriteLine(personajesJson);
                }
            };

        }

        public List<Personaje> LeerPersonajes(string nombreArchivo)
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

            var listaPersonajesLeidos = JsonSerializer.Deserialize<List<Personaje>>(archivoExtraido, opciones)?? new List<Personaje>();
            if (listaPersonajesLeidos != null)
            {
                foreach (var personaje in listaPersonajesLeidos)
                {
                    personaje.Caracteristica ??= new Caracteristica();
                }
            }
            return listaPersonajesLeidos!;
        }

        public bool ExisteArchivo(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                FileInfo fileInfo = new(nombreArchivo);
                return fileInfo.Length > 0;
            }
            else
            {
                return false;
            }
        }
    }
}