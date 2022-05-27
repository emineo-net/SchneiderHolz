//using System.ComponentModel;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Authorization;
//using XeniaPro.Authentication.Contract.Service;

//namespace WebsitesTrackerBlazor.Components;

//public class Logout : ComponentBase
//{
//    [Inject] protected NavigationManager NavigationManager { get; set; }
//    [Inject] public IAccountService AccountService { get; set; }


//    [Localizable(false)]
//    protected override void OnInitialized()
//    {
//        AccountService.LogoutAsync();
//        try
//        {
//            NavigationManager.NavigateTo("login");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine("RedirectToLogin:" + ex.Message);
//        }
//    }
//}