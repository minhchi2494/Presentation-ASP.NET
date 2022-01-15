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
    public partial class AddSettingComponent : ComponentBase
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

        Dm1.Models.Dm.Setting _setting;
        protected Dm1.Models.Dm.Setting setting
        {
            get
            {
                return _setting;
            }
            set
            {
                if (!object.Equals(_setting, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "setting", NewValue = value, OldValue = _setting };
                    _setting = value;
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
            setting = new Dm1.Models.Dm.Setting(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(Dm1.Models.Dm.Setting args)
        {
            try
            {
                var dmCreateSettingResult = await Dm.CreateSetting(setting);
                DialogService.Close(setting);
            }
            catch (System.Exception dmCreateSettingException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new Setting!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
