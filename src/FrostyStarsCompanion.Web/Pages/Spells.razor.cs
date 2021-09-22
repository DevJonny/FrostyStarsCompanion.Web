using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrostyStarsCompanion.Web.Model.Frostgrave;
using FrostyStarsCompanion.Web.Services;
using Microsoft.AspNetCore.Components;

namespace FrostyStarsCompanion.Web.Pages
{
    public class SpellsBase : ComponentBase
    {
        [Inject] public IDataStore<Model.Frostgrave.Warband> DataStore { get; set; }

        [Parameter] public string Id { get; set; }
        [Parameter] public string IsWizard { get; set; }

        protected IEnumerable<Spell> Spells { get; set; } = Enumerable.Empty<Spell>();

        protected override async Task<Task> OnParametersSetAsync()
        {
            var warband = await DataStore.Get(Guid.Parse(Id));
            
            Spells = bool.Parse(IsWizard) ? warband.Wizard.Spells() : warband.Apprentice.Spells();

            StateHasChanged();

            return base.OnParametersSetAsync();
        }    
    }
}