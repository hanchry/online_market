using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Algorithm.Model;

namespace Algorithm.Data
{
    public class ItemsController
    {
        private readonly HttpClient client;
        private HttpClientHandler clientHandler;

        public ItemsController()
        {
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            client = new HttpClient(clientHandler);
        }

        public async Task<IList<Item>> GetAllPricesOfItemAsync(string id, int qualities)
        {
            String reply = null;
            try
            {
                List<Item> items = new List<Item>();
                HttpResponseMessage responseMessage =
                    await client.GetAsync($"{APIurl.URL}/api/v2/stats/prices/{id}.json?qualities={qualities}");

                if (responseMessage.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new Exception(responseMessage.Content.ReadAsStringAsync().Result);
                }

                reply = await responseMessage.Content.ReadAsStringAsync();
                items = JsonSerializer.Deserialize<List<Item>>(reply);
                return items;
            }
            catch (Exception e)
            {
                Console.WriteLine(reply);
                Console.WriteLine(e);
                throw;
            }
        }
    }
}