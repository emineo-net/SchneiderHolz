namespace SchneiderHolzBlazorApp.Pages.TransportOrderFeature.Components;

public partial class Store
{
    [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; } = default!;
    private ILogger<TransportOrderDetail> Logger { get; set; }
    [Parameter] public TransportOrder SelectedItem { get; set; }


    private async Task ValidSubmit()
    {
        throw new NotImplementedException();
    }

}
