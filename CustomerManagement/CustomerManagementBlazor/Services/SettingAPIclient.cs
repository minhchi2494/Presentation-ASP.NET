using CustomerManagementModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CustomerManagementBlazor.Services
{
    public class SettingAPIclient : ISettingAPIclient
    {
        public HttpClient _httpClient;
        public SettingAPIclient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<SettingDTO>> GetSettingList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SettingDTO>>(requestUri:"/api/customersettings");
            return result;
        }
        
    }
}

