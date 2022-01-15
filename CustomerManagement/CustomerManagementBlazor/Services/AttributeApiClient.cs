
using CustomerManagementModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CustomerManagementBlazor.Services
{
    public class AttributeApiClient : IAttributeApiClient
    {
        public HttpClient _httpClient;
        public AttributeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateAttribute(CreateAttributeModel request)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/customerattributes", request);
            return result.IsSuccessStatusCode;

        }

        public async Task<List<AttributeDTO>> GetAttributeList(SearchAttributes searchAttributes)
        {
           
            var result = await _httpClient.GetFromJsonAsync<List<AttributeDTO>>(requestUri:$"/api/customerattributes?AttributeMaster={searchAttributes.AttributeMaster}");
            return result;
        }


    }
}
