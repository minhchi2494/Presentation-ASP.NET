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
    public partial class EditAttributeComponent : ComponentBase
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

        [Parameter]
        public dynamic Code { get; set; }

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

        Dm1.Models.Dm.Attribute __attribute;
        protected Dm1.Models.Dm.Attribute _attribute
        {
            get
            {
                return __attribute;
            }
            set
            {
                if (!object.Equals(__attribute, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "_attribute", NewValue = value, OldValue = __attribute };
                    __attribute = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

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
            var dmGetAttributesResult = await Dm.GetAttributes();
            getAttributesResult = dmGetAttributesResult;

            var dmGetAttributeByCodeResult = await Dm.GetAttributeByCode($"{Code}");
            _attribute = dmGetAttributeByCodeResult;

            var dmGetSettingsResult = await Dm.GetSettings();
            getSettingsResult = dmGetSettingsResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(Dm1.Models.Dm.Attribute args)
        {
            try
            {
                var dmUpdateAttributeResult = await Dm.UpdateAttribute($"{Code}", _attribute);
                DialogService.Close(_attribute);
            }
            catch (System.Exception dmUpdateAttributeException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update Attribute" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
