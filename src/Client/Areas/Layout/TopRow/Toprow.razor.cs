using Blazored.Modal;
using Blazored.Modal.Services;
using FBTracker.Client.State;
using FBTracker.Client.State.Components;
using Microsoft.AspNetCore.Components;

namespace FBTracker.Client.Areas.Layout.TopRow;
partial class TopRow : ComponentBase
{
    [CascadingParameter]
    private  AppState State { get; set; } = default!;

        [CascadingParameter]
    public IModalService Modal { get; set; } = default!;
    private async Task ChangeSeason()
    {
        var parameters = new ModalParameters()
            .Add(nameof(SeasonSelect.Season), State.Season);

        var options = new ModalOptions 
            { Class = "season-select" };

        var modal = Modal.Show<SeasonSelect>("Select Season", parameters, options);
        var result = await modal.Result;
        
        if (result.Confirmed)
        {
            var success = Int32.TryParse(result.Data.ToString(), out int newSeason);

            if (success && newSeason != State.Season)
            {
                await SelectNewSeason(newSeason);
            }
        }
    }

    private async Task SelectNewSeason(int season)
    {
        await State.ChangeSelectedSeason(season);
    }
}
