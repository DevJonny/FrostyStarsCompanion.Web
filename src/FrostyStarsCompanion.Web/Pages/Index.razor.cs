using System.Threading.Tasks;
using FrostyStarsCompanion.Web.Services;
using FrostyStarsCompanion.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using WarbandModel = FrostyStarsCompanion.Web.Model.Frostgrave.Warband;

namespace FrostyStarsCompanion.Web.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject] public IDataStore<WarbandModel> WarbandDataStore { get; set; }

        public IndexViewModel ViewModel { get; } = new();

        protected override async Task OnInitializedAsync()
        {
            ViewModel.Warbands = await WarbandDataStore.GetAll();
            
            await base.OnInitializedAsync();
        }
    }
}