namespace SchneiderHolzBlazorApp.Pages.TransportOrderDir;

public partial class TranportOrderPage
{
    [Inject] private HttpClient Http { get; set; }
    private List<TransportOrder> data = new();

    public TransportOrder SelectedItem = new();
    public List<TransportOrder> SelectedItems = new();
    public ITable<TransportOrder> Table;

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

        data = await Http.GetFromJsonAsync<List<TransportOrder>>($"{Http.BaseAddress}/TransportOrders");


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

    public async Task Save()
    {
        foreach (var item in data)
        {
            await Http.PutAsJsonAsync($"{Http.BaseAddress}/TransportOrders/" + Convert.ToInt32(item.Id), item);
        }
    }




}
