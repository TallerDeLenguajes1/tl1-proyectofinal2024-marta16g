using System.Text.Json;
using EspacioClima;

namespace EspacioApi
{
    public class Api
    {
        private static readonly HttpClient client = new();

        public async void ObtenerApi()
        {
            try
            {
                var url = "https://api.open-meteo.com/v1/forecast?latitude=51.5085&longitude=-0.1257&current=temperature_2m,apparent_temperature,is_day,rain,weather_code&timezone=Europe%2FLondon";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Clima clima = JsonSerializer.Deserialize<Clima>(responseBody);

                if (clima != null)
                {
                    DateTime fecha = new();
                    fecha = DateTime.Parse(clima.current.time);
                    string hora = fecha.ToString("HH:mm"); 
                    Console.WriteLine("Londres, Inglaterra");
                    Console.WriteLine($"Hora: {hora}");
                    switch (clima.current.weather_code)
                    {
                        case 0: Console.WriteLine("El sol irradia sobre el cielo azul. Buen día para un duelo.");
                        break;
                        case 1:
                        case 2:
                        case 3: Console.WriteLine("Las nubes se hacen presentes ante el duelo."); 
                        break;
                        case 45:
                        case 48: Console.WriteLine("El ambiente del duelo es invadido por una neblina temerosa."); 
                        break;
                        case 71:
                        case 73:
                        case 75:
                        case 77: Console.WriteLine("Copos de nieve empiezan a caer sobre los magos.");
                        break;
                        case 61:
                        case 63:
                        case 65:
                        case 66:
                        case 67:
                        case 80:
                        case 81:
                        case 82: Console.WriteLine("El temible inicio de un nuevo duelo desata una lluvia estripitosa");
                        break; 
                        case 95:
                        case 96:
                        case 99: Console.WriteLine("Los magos deberán tener cuidado. Una tormenta se acerca"); 
                        break;

                        default: Console.WriteLine("Una llovizna cae sobre los cabellos de los magos. Mejor apurar el duelo si no quieren agarrar un resfriado");
                        break;
                    }
                    Console.WriteLine($"Temperatura: {clima.current.temperature_2m}");


                   
                }
                
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error al acceder a la API: {e.Message}"); 
            }
            catch (JsonException e)
            {
                Console.WriteLine($"Error al deserializar la respuesta de la API: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocurrió un error inesperado: {e.Message}");
            }

        }

    }
}