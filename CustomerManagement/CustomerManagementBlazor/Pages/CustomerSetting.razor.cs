using CustomerManagementBlazor.Services;
using CustomerManagementModel;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagementBlazor.Pages
{
    public partial class CustomerSetting
    {
        [Inject] public ISettingAPIclient SettingAPIclient { get; set; }

        public List<SettingDTO> settings;
        protected override async Task OnInitializedAsync()
        {
             settings = await SettingAPIclient.GetSettingList(); 
        }
    }
}
