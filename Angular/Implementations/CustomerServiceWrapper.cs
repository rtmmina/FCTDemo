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
    public class CustomerServiceWrapper : ICustomerServiceWrapper
    {
        private readonly HttpClient client;
        public CustomerServiceWrapper(HttpClient Client)
        {
            client = Client;
            client.BaseAddress = new Uri("https://localhost:44358/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public List<Customer> Get()
        {
            var data = new List<Customer>();

            var responseTask = client.GetAsync("Customer");
            responseTask.Wait();
            

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                data = JsonConvert.DeserializeObject<List<Customer>>(readTask.Result);
            }

            return data;
        }

        public Customer Post(Customer customer)
        {
            var data = new Customer();
            StringContent request = new StringContent(JsonConvert.SerializeObject(customer), UnicodeEncoding.UTF8, "application/json");
            var responseTask = client.PostAsync("Customer", request);

            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                data = JsonConvert.DeserializeObject<Customer>(readTask.Result);
            }

            return data;

        }

        public Login ValidateLogin(Login customer)
        {
            var mappedCustomer = new Customer()
            {
                Email = customer.Email,
                Password = customer.Password
            };
            StringContent request = new StringContent(JsonConvert.SerializeObject(mappedCustomer), UnicodeEncoding.UTF8, "application/json");
            var responseTask = client.PostAsync("Customer/ValidateCustomer", request);

            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                mappedCustomer = JsonConvert.DeserializeObject<Customer>(readTask.Result);
            }

            var rVal = new Login()
            {
                Email = mappedCustomer.Email,
                ID = mappedCustomer.ID,
                Name = mappedCustomer.Name,
                Password = mappedCustomer.Password
            };

            return rVal;
        }
    }
}
