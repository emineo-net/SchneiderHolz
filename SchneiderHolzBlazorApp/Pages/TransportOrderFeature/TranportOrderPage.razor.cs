using SchneiderHolzBlazorApp.Pages.TransportOrderFeature.Components;

namespace SchneiderHolzBlazorApp.Pages.TransportOrderFeature;

public partial class TranportOrderPage
{
    private ObjectsToString objectsToString = new ObjectsToString();
    private List<TransportOrder> _data = new();
    public TransportOrder SelectedItem = new();
    public List<TransportOrder> SelectedItems = new();
    public ITable<TransportOrder> Table;
    [Inject] private HttpClient HttpClient { get; set; } = new();


    protected override async Task OnInitializedAsync()
    {
        _data = await HttpClient.GetFromJsonAsync<List<TransportOrder>>($"{HttpClient.BaseAddress}/TransportOrders") ??
               new List<TransportOrder>();
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


    public async Task StorePackage()
    {
        if (string.IsNullOrEmpty(SelectedItem.PackageNumber))
        {
            toastService.ShowWarning("No package selected.");
            return;
        }

        var parameters = new ModalParameters();
        parameters.Add(nameof(Store.SelectedItem), SelectedItem);
        var messageForm = Modal.Show<Store>(
            SelectedItem.PackageNumber,
            parameters, new ModalOptions { Class = EditModalClass });

        var result = await messageForm.Result;
        var resultObj = (TransportOrder)result.Data;
        if (resultObj == null)
        {
        }
        else if (!result.Cancelled)
        {
            _data.Add(resultObj);
        }

        else if (result.Cancelled)
        {
        }

        StateHasChanged();
    }

    public async Task OutsourcePackage()
    {
        if (string.IsNullOrEmpty(SelectedItem.PackageNumber))
        {
            toastService.ShowWarning("No package selected.");
            return;
        }

        var parameters = new ModalParameters();
        parameters.Add(nameof(Outsource.SelectedItem), SelectedItem);
        var messageForm = Modal.Show<Outsource>(
            SelectedItem.PackageNumber,
            parameters, new ModalOptions { Class = EditModalClass });

        var result = await messageForm.Result;
        var resultObj = (TransportOrder)result.Data;
        if (resultObj == null)
        {
        }
        else if (!result.Cancelled)
        {
            _data.Add(resultObj);
        }

        else if (result.Cancelled)
        {
        }

        StateHasChanged();
    }

    public async Task RelocatePackage()
    {
        if (string.IsNullOrEmpty(SelectedItem.PackageNumber))
        {
            toastService.ShowWarning("No package selected.");
            return;
        }

        var parameters = new ModalParameters();
        parameters.Add(nameof(Relocate.SelectedItem), SelectedItem);
        var messageForm = Modal.Show<Relocate>(
            SelectedItem.PackageNumber,
            parameters, new ModalOptions { Class = EditModalClass });

        var result = await messageForm.Result;
        var resultObj = (TransportOrder)result.Data;
        if (resultObj == null)
        {
        }
        else if (!result.Cancelled)
        {
            _data.Add(resultObj);
        }

        else if (result.Cancelled)
        {
        }

        StateHasChanged();
    }


    public async Task ShowModalEdit(TransportOrder select)
    {
        var isNew = false;

        if (select == null)
        {
            select = new TransportOrder();
            isNew = true;
        }
        var parameters = new ModalParameters();
        parameters.Add(nameof(TransportOrderDetail.SelectedItem), select);
        var messageForm = Modal.Show<TransportOrderDetail>(@"TransportOrderDetails",parameters, new ModalOptions { Class = EditModalClass });
        var result = await messageForm.Result;
        var resultObj = (TransportOrder)result.Data;

        if (result.Cancelled)
        { }
        else if (resultObj == null)
        {
            // TODO: log error
        }
        else if (!result.Cancelled)
        {
            if (isNew)
            {
                _data.Add(resultObj);
            }
        }
        StateHasChanged();
    }


    private void ToggleEdit()
    {
        var resttest = SelectedItem.ToString();

        Table.ToggleEditMode();
    }

    public async Task Save()
    {
        foreach (var item in _data)
            await HttpClient.PutAsJsonAsync($"{HttpClient.BaseAddress}/TransportOrders/" + Convert.ToInt32(item.Id),
                item);
    }
}