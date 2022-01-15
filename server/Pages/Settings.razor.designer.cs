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
    public partial class SettingsComponent : ComponentBase
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
        protected RadzenDataGrid<Dm1.Models.Dm.Setting> grid0;

        IEnumerable<Dm1.Models.Dm.Setting> _getSettingsResult;
        protected IEnumerable<Dm1.Models.Dm.Setting> getSettingsResult
        {
            get
            {
                return _getSettingsResult;
            }
            set
            {
                if (!object.Equals(_getSettingsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getSettingsResult", NewValue = value, OldValue = _getSettingsResult };
                    _getSettingsResult = value;
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
            var dmGetSettingsResult = await Dm.GetSettings();
            getSettingsResult = dmGetSettingsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddSetting>("Add Setting", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<Dm1.Models.Dm.Setting> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditSetting>("Edit Setting", new Dictionary<string, object>() { {"AttributeID", args.Data.AttributeID} });
            await InvokeAsync(() => { StateHasChanged(); });
        }
    }
}
