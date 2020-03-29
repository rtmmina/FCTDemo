using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using Common.DTO;

namespace WebApiClientTester
{
    class Program
    {       

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                using (var client = new HttpClient())
                {
                    var customer = new Customer()
                    {
                        Email = "test@test.com",
                        Name = "test",
                        Password = "newPassword"
                    };
                    StringContent request = new StringContent(JsonConvert.SerializeObject(customer), UnicodeEncoding.UTF8, "application/json");

                    client.BaseAddress = new Uri("https://localhost:44358/api/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    //HTTP GET
                    var responseTask = client.PostAsync("Customer", request);
                    //var responseTask = client.GetAsync("Customer");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();

                        var response = JsonConvert.DeserializeObject<Customer>(readTask.Result);
                    }
                }
            }
            catch(Exception ex)
            {
                var d = "wait";
            }
            Console.ReadLine();
        }
    
    }
}
