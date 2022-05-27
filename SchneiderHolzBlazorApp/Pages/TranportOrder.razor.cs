namespace SchneiderHolzBlazorApp.Pages;

public partial class TranportOrder
{
    [Inject] private HttpClient Http { get; set; }

    private List<TransportOrder> data = new();
   
    int selectedWebsiteProjectId;
    int SelectedWebsiteProjectId
    {
        get => selectedWebsiteProjectId;
        set
        {
            selectedWebsiteProjectId = value;
           
            // SelectSite(true);
        }
    }


    protected override async Task OnInitializedAsync()
    {

        data = await Http.GetFromJsonAsync < List<TransportOrder>>($"{Http.BaseAddress}/api/TransportOrders");


    }

    private async Task Delete(TransportOrder select)
    {
        var messageForm =
            Modal.Show<Confirm>(
                $@" {select.Target}{select.Id}?");
        var result = await messageForm.Result;

        if (!result.Cancelled)
        {

        }
    }

    public async Task ShowModalEdit(TransportOrder select)
    {
        if (select == null)
        {
            select = new TransportOrder();
            //select.Id = data.Count == 0 ? 1 : data.OrderByDescending(id => id.Id).First().Id + 1;
        }

        var parameters = new ModalParameters();
        parameters.Add(nameof(TransportOrderDetail.SelectedItem), select);
        var messageForm = Modal.Show<TransportOrderDetail>(
            $@"title needs to localize",
            parameters, new ModalOptions { Class = EditModalClass });

        var result = await messageForm.Result;
        var resultObj = (TransportOrder)result.Data;
        if (resultObj == null)
        {
        }
        else if (!result.Cancelled)
        {
            data.Add(resultObj);
        }

        else if (result.Cancelled)
        {
        }
        StateHasChanged();
    }


   
    private void ToggleEdit()
    {
        Table.ToggleEditMode();
    }

    public async ValueTask DisposeAsync()
    {
        // await SomeTyp.CloseAsync();
    }

   



}
