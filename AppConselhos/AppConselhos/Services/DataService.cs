using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using AppConselhos.Model;
using System.Data;

namespace AppConselhos.Services
{
    class DataService
    {
        public static async Task<Conselhos> GetConselhosTwitter()
        {
            string queryString = "https://api.adviceslip.com/advice";
            dynamic resultado = await GetDataFromService(queryString).ConfigureAwait(false);

            if (resultado["Conselhos"] !=null)
            {
                Conselhos conselhos = new Conselhos();
                conselhos.Id = (string) resultado ["id"];
                conselhos.Frase = (string)resultado["Conselhinhos"];
                return conselhos;
            }
            else
            {
                return null;
            }
        }

        public static async Task<dynamic> GetDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);
            dynamic data = null;
            if (response != null)
            {
                string json =  response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<dynamic>(json);
            }
            return data;
        }
    }
}
