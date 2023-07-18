using System.ComponentModel.DataAnnotations;
using Blazored.Modal;
using Blazored.Modal.Services;
using FBTracker.Shared.GlobalConstants;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace FBTracker.Client.State.Components;
partial class SeasonSelect : ComponentBase
{
    private class InputModel
    {
        [Required]
        [Range(2020, 2023, ErrorMessage ="Season must be 2020 - 2023")]
        public int Season { get; set;} = 0;
    }

    private readonly InputModel _model = new();
    private string _errorMessage = "";
    public EditContext? _editContext;

    [CascadingParameter]
    public BlazoredModalInstance ModalInstance { get; set; } = default!;
    
    [Parameter] public int Season  { get; set; } = 0;
        

    protected override void OnInitialized()
    {
        ModalInstance.SetTitle("Select Season");
        _model.Season = Season;
        _editContext = new(_model);
    }

    public async Task Submit()
    {
        if (_editContext is not null)
        {
            switch(_model.Season)
            {
                case < StateConstants.seasonMin:
                    _errorMessage = $"Season must be {StateConstants.seasonMin} or greater";
                return;

                case > StateConstants.seasonMax:
                    _errorMessage = $"Season must be {StateConstants.seasonMax} or less";
                return;

                default:
                    await ModalInstance.CloseAsync(ModalResult.Ok(_model.Season));
                    break;
            }
        }
    }
    
    public async Task Cancel() =>
        await ModalInstance.CancelAsync();

}

