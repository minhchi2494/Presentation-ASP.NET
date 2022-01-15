using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Dm1.Models.Dm;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Dm1.Models;

namespace Dm1.Pages
{
    public partial class AttributesComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected DmService Dm { get; set; }

        [Inject]
        protected DemoSecurityService DemoSecurity { get; set; }
        protected RadzenDataGrid<Dm1.Models.Dm.Attribute> grid0;

        IEnumerable<Dm1.Models.Dm.Attribute> _getAttributesResult;
        protected IEnumerable<Dm1.Models.Dm.Attribute> getAttributesResult
        {
            get
            {
                return _getAttributesResult;
            }
            set
            {
                if (!object.Equals(_getAttributesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getAttributesResult", NewValue = value, OldValue = _getAttributesResult };
                    _getAttributesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Security.InitializeAsync(AuthenticationStateProvider);
            if (!Security.IsAuthenticated())
            {
                UriHelper.NavigateTo("Login", true);
            }
            else
            {
                await Load();
            }
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var dmGetAttributesResult = await Dm.GetAttributes(new Query() { Expand = "Setting" });
            getAttributesResult = dmGetAttributesResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddAttribute>("Add Attribute", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Button1Click(MouseEventArgs args)
        {
            await Dm.ExportAttributesToExcel();
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            await Dm.ExportAttributesToExcel();
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<Dm1.Models.Dm.Attribute> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditAttribute>("Edit Attribute", new Dictionary<string, object>() { {"Code", args.Data.Code} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var dmDeleteAttributeResult = await Dm.DeleteAttribute($"{data.Code}");
                    if (dmDeleteAttributeResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception dmDeleteAttributeException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Attribute" });
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var dmDeleteAttributeResult = await Dm.DeleteAttribute($"{data.Code}");
                    if (dmDeleteAttributeResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception dmDeleteAttributeException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Attribute" });
            }
        }
    }
}
