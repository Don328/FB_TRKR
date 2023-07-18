using Microsoft.AspNetCore.Components;

namespace FBTracker.Client.Areas.Layout.NavBar;
public partial class NavButton : ComponentBase
{
    [Inject, EditorRequired]
    public NavigationManager NavMan { get; set;} = default!;

    [Parameter, EditorRequired]
    public string Text { get; set; } = "Button";

    [Parameter, EditorRequired]
    public string Route { get; set;} = "";

    private void OnClick()
    {
        NavMan.NavigateTo(Route);
    }
}
