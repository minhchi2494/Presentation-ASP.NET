using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Services;
using BlazorApp.Models;
using BlazorApp.Component;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp.Pages
{
    public partial class CustomerAttributeView
    {
        [Inject]
        private ICustomerService _services { get; set; }
        private List<CustomerAttributeModel> model;
        private CustomerSearch CustomerSearch = new CustomerSearch();
        protected Confirmation DeleteConfirmation { set; get; }

        private int DeleteId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            model = await _services.getAll(CustomerSearch);
        }

        private async Task SeachForm(EditContext context)
        {
            model = await _services.getAll(CustomerSearch);
        }

        public void OnDeleteTask(int deleteId)
        {
            DeleteId = deleteId;
            DeleteConfirmation.Show();
        }

        public async Task OnConfirmDeleteTask(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await _services.Delete(DeleteId);
                model = await _services.getAll(CustomerSearch);
            }
        }
    }
}
