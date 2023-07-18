using FBTracker.Client.State;
using Microsoft.AspNetCore.Components;

namespace FBTracker.Client.Areas.Home;

partial class HomePage : ComponentBase
{
    [CascadingParameter]
    public AppState State { get; set;} = default!;

}