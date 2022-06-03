using Localization;

namespace SchneiderHolzBlazorApp.Components;

public partial class LabelLocalizeable
{
    [Inject] private ILocalizer L { get; set; }
    [Parameter] public string TranslateKey { get; set; }
    [Parameter] public string For { get; set; }

    [Parameter] public string CssClass { get; set; }

    //[Parameter] public Guid Tenant { get; set; }
    private Localize SelectedItem { get; set; }

    private string Translated { get; set; }
}