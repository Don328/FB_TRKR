using FB_Tracker.Shared.Models;
using FBTracker.Client.DataServices;
using FBTracker.Client.State;
using FBTracker.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace FBTracker.Client.Areas.Teams;

partial class TeamsPage : ComponentBase
{
    [Inject]
    public TeamDataService _teamsService { get; set; } = default!;

    [CascadingParameter]
    public AppState State { get; set;} = default!;

    private async Task UpdateTeamData(TeamDTO dto)
    {
        await _teamsService.UpdateTeamData(dto);
    }

}
