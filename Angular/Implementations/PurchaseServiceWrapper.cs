using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular.Contracts;
using Common.DTO;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace Angular.Implementations
{
    public class PurchaseServiceWrapper : IPurchaseServiceWrapper
    {
        private readonly HttpClient client;

        public PurchaseServiceWrapper(HttpClient Client)
        {
            client = Client;
            client.BaseAddress = new Uri("https://localhost:44358/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public bool Delete(int id)
        {
            var data = false;
            StringContent request = new StringContent(JsonConvert.SerializeObject(id), UnicodeEncoding.UTF8, "application/json");
            var responseTask = client.DeleteAsync("Purchase");
            responseTask.Wait();


            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                data = JsonConvert.DeserializeObject<bool>(readTask.Result);
            }

            return data;
        }

        public List<PurchaseDetails> Get()
        {
            var data = new List<PurchaseDetails>();

            var responseTask = client.GetAsync("Purchase");
            responseTask.Wait();


            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                data = JsonConvert.DeserializeObject<List<PurchaseDetails>>(readTask.Result);
            }

            return data;
        }

        public PurchaseDetails Post(PurchaseDetails purchase)
        {
            var data = new PurchaseDetails();
            StringContent request = new StringContent(JsonConvert.SerializeObject(purchase), UnicodeEncoding.UTF8, "application/json");
            var responseTask = client.PostAsync("Purchase", request);

            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                data = JsonConvert.DeserializeObject<PurchaseDetails>(readTask.Result);
            }

            return data;
        }
    }
}
