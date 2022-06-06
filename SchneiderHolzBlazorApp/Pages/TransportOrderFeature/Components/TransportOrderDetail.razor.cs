namespace SchneiderHolzBlazorApp.Pages.TransportOrderFeature.Components;

public partial class TransportOrderDetail
{
    [CascadingParameter] private BlazoredModalInstance BlazoredModal { get; set; } = default!;
    private ILogger<TransportOrderDetail> Logger { get; set; }
    [Parameter] public TransportOrder SelectedItem { get; set; }
    [Inject] private HttpClient HttpClient { get; set; } = new();


    private async Task ValidSubmit()
    {
        if (SelectedItem.Id == 0)
        {
            var response = await HttpClient.PostAsJsonAsync($"{HttpClient.BaseAddress}/TransportOrders/", SelectedItem);
            var responseContent = await response.Content.ReadAsStringAsync();
            var newItem = JsonSerializer.Deserialize<TransportOrder>(responseContent);
            SelectedItem.Id = newItem.Id;
        }
        else
        {
            await HttpClient.PutAsJsonAsync($"{HttpClient.BaseAddress}/TransportOrders/" + SelectedItem.Id, SelectedItem);
        }
        await BlazoredModal.CloseAsync(ModalResult.Ok(SelectedItem));
    }
}