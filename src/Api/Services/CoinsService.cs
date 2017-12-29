using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Api.Models;

namespace Api.Services
{
    public class CoinsService
    {
        private readonly HttpClient httpClient;
        public CoinsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<CoinModel[]> GetAllCoins()
        {
            return await GetAsync<CoinModel[]>("v1/ticker/");
        }

        private async Task<TResult> GetAsync<TResult>(string uri, string value = null)
        {
            try
            {
                uri = string.IsNullOrEmpty(value) ? $"{uri}" : $"{uri}/{value}";
                return await httpClient.GetAsync(uri).ContinueWith(responseMessage =>
                 {
                     var resposne = responseMessage.Result;
                     if (!resposne.IsSuccessStatusCode)
                     {
                         //log error
                         return null;
                     }
                     return resposne.Content.ReadAsStringAsync().ContinueWith(jsonTask =>
                     {
                         return JsonConvert.DeserializeObject<TResult>(jsonTask.Result);
                     });
                 }).Unwrap();
            }
            catch (Exception e)
            {
                //log error
                return default(TResult);
            }
        }
    }
}