using FB_Tracker.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace FBTracker.Client.Areas.Teams.Components;
partial class TeamDisplay : ComponentBase 
{
    [Parameter, EditorRequired]
    public Team Team { get; set; } = default!;
}
