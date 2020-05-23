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
    public class ProductServiceWrapper : IProductServiceWrapper
    {
        private readonly HttpClient client;

        public ProductServiceWrapper(HttpClient Client)
        {
            client = Client;
            client.BaseAddress = new Uri("https://localhost:44358/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public List<Product> Get()
        {
            var data = new List<Product>();

            var responseTask = client.GetAsync("Product");
            responseTask.Wait();


            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                data = JsonConvert.DeserializeObject<List<Product>>(readTask.Result);
            }

            return data;
        }

        public Product Post(Product product)
        {
            var data = new Product();
            StringContent request = new StringContent(JsonConvert.SerializeObject(product), UnicodeEncoding.UTF8, "application/json");
            var responseTask = client.PostAsync("Product", request);

            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                data = JsonConvert.DeserializeObject<Product>(readTask.Result);
            }

            return data;
        }
    }
}
