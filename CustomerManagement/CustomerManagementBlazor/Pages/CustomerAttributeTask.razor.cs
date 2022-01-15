using CustomerManagementBlazor.Services;
using CustomerManagementModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagementBlazor.Pages
{
    public partial class CustomerAttributeTask
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] public IAttributeApiClient AttributeApiClient { get; set; }
        private CreateAttributeModel createAttribute = new CreateAttributeModel();
        public List<AttributeDTO> attributes;
        
        public SearchAttributes SearchAttributes =new SearchAttributes();
        protected async override  Task OnInitializedAsync()
        {
            attributes = await AttributeApiClient.GetAttributeList(SearchAttributes);
        }

        public async Task SearchForm(EditContext context)
        {
            attributes = await AttributeApiClient.GetAttributeList(SearchAttributes);
        }
        public async Task SubmitCreate(EditContext context)
        {
            var result = await AttributeApiClient.CreateAttribute(createAttribute);
            if(result)
            {
                NavigationManager.NavigateTo("/CustomerAttribute");
            }    
        }
    }


   
}
