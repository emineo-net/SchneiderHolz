using System.ComponentModel;
using Microsoft.AspNetCore.Components;

namespace SchneiderHolzBlazorApp.Components;

public class RedirectToLogin : ComponentBase
{
    [Inject] protected NavigationManager NavigationManager { get; set; }

    [Localizable(false)]
    protected override void OnInitialized()
    {
        try
        {
            NavigationManager.NavigateTo("login");
            //NavigationManager.NavigateTo("tablelayouter");
        }
        catch (Exception ex)
        {
            Console.WriteLine("RedirectToLogin:" + ex.Message);
        }
    }
}