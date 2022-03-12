using JaarConsultTeste.Data.Dtos;
using System.Net.Http.Headers;
using System.Text.Json;

namespace JaarConsultTeste.Services
{
    public class BrasilAPIService
    {
        private static HttpClient _client;

        public BrasilAPIService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://brasilapi.com.br/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<ReadFipeDto>> RecuperaDadosPorFipe(string codigoFipe)
        {
            string pathResource = $"api/fipe/preco/v1/{codigoFipe}";
            HttpResponseMessage response = await _client.GetAsync(pathResource);
            List<ReadFipeDto> listaModelos = new List<ReadFipeDto>();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    listaModelos = await response.Content.ReadFromJsonAsync<List<ReadFipeDto>>();
                }
                catch (Exception e)
                {

                }
                
            }

            return listaModelos;
        }
    }
}
