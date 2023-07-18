using Microsoft.AspNetCore.Components;

namespace FBTracker.Client.Areas.Layout;
partial class Tooltip : ComponentBase
{
    [Parameter] public RenderFragment 
    ChildContent { get; set; } = default!;

    [Parameter] public string 
    Text { get; set; } = default!;
}
