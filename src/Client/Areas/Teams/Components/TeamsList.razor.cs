using FB_Tracker.Shared.Models;
using FBTracker.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace FBTracker.Client.Areas.Teams.Components;
partial class TeamsList : ComponentBase
{
    [Parameter, EditorRequired]
    public IEnumerable<Team> Teams { get; set; } = default!;

    [Parameter, EditorRequired]
    public bool TeamsConfirmed { get; set; }

    [Parameter, EditorRequired]
    public bool SchedulesConfirmed { get; set; }

    [Parameter, EditorRequired]
    public EventCallback<TeamDTO> OnUpdateTeamData { get; set; }

    private async Task UpdateTeamData(TeamDTO dto)
    {
        await OnUpdateTeamData.InvokeAsync(dto);
    }
}
