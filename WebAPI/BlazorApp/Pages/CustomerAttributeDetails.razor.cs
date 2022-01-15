using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Services;
using BlazorApp.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages
{
    public partial class CustomerAttributeDetails
    {
        [Inject]
        private ICustomerService services { get; set; }

        private CustomerAttributeModel CustomerAttribute { set; get; }

        [Parameter]
        public int id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            CustomerAttribute = await services.GetOne(id);
        }


    }
}
