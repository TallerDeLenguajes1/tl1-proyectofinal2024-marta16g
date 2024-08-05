using System.Text.Json;
using EspacioClima;
using Microsoft.VisualBasic;

namespace EspacioApi
{
    public class Api
    {
        private static readonly HttpClient client = new();

        public async Task<Clima> ObtenerApi()
        {
            try
            {
                var url = "https://goweather.herokuapp.com/weather/london";
                HttpResponseMessage  response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Clima clima = JsonSerializer.Deserialize<Clima>(responseBody);
                return clima;
            }
            catch (System.Exception)
            {
                throw;
            }

        }

    }
}