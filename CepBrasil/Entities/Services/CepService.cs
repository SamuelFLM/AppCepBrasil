using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cep.Entities;
using Newtonsoft.Json;

namespace CepBrasil.Entities.Services
{
    class CepService
    {

        private readonly HttpClient _http;
        private readonly string _url;

        public CepService()
        {
            _http = new HttpClient();
            _url = "https://viacep.com.br/ws/";
        }

        public async Task<BrazilCep> Get(int cep)
        {
            try
            {
                var response = await _http.GetAsync($"{_url}{cep}/json");

                var jsonString = await response.Content.ReadAsStringAsync();

                BrazilCep objetoJson = JsonConvert.DeserializeObject<BrazilCep>(jsonString);

                return objetoJson;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
    }
}
