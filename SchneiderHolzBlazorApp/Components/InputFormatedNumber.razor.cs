namespace SchneiderHolzBlazorApp.Components;

public partial class InputFormatedNumber
{
    [Parameter] public string TranslateKey { get; set; }
    [Parameter] public string CssClass { get; set; }


    protected override async Task OnInitializedAsync()
    {
    }
}