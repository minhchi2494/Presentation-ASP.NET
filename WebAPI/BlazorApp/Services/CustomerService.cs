using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BlazorApp.Services
{
    public class CustomerService : ICustomerService
    {
        public HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CustomerAttributeModel>> getAll(CustomerSearch customerSearch)
        {
            string url = $"/api/CustomerAttribute?AttributeMaster={customerSearch.AttributeMaster}";
            var result = await _httpClient.GetFromJsonAsync<List<CustomerAttributeModel>>(url);
            return result;
        }

        public async Task<CustomerAttributeModel> GetOne(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<CustomerAttributeModel>($"/api/CustomerAttribute/{id}");
            return result;
        }

        public async Task<bool> Create(CustomerAttributeModel newCust)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/CustomerAttribute", newCust);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Edit(CustomerAttributeModel newCust)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/CustomerAttribute", newCust);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"/api/CustomerAttribute/{id}");
            return result.IsSuccessStatusCode;
        }
    }
}
