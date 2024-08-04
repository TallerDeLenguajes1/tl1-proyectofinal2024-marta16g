using System.Text.Json;
using Microsoft.VisualBasic;

namespace EspacioApi
{
    public class Api
    {
        private static readonly HttpClient client = new();

        public async void ObtenerApi()
        {
            try
            {
                var url = "https://api.generadordni.es/v2/text/paragraphs?results=2&sentences=1&language=es";
                HttpResponseMessage  response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

            }
            catch (System.Exception)
            {
                throw;
            }

        }

    }
}