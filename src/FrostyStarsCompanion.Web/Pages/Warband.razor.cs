using System;
using System.Threading.Tasks;
using FrostyStarsCompanion.Web.Services;
using FrostyStarsCompanion.Web.ViewModels;
using Microsoft.AspNetCore.Components;

namespace FrostyStarsCompanion.Web.Pages
{
    public class WarbandBase : ComponentBase
    {
        [Inject] public IDataStore<Model.Frostgrave.Warband> DataStore { get; set; }

        [Parameter] public string Id { get; set; }

        protected WarbandViewModel ViewModel { get; } = new();

        protected override async Task<Task> OnParametersSetAsync()
        {
            ViewModel.Warband = await DataStore.Get(Guid.Parse(Id));

            StateHasChanged();

            return base.OnParametersSetAsync();
        }
    }
}