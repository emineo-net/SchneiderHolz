using System.Globalization;
using Blazored.FluentValidation;
using Microsoft.AspNetCore.Components.Authorization;

namespace SchneiderHolzBlazorApp.Pages;

public class MyComponentBase : ComponentBase
{
    public string CssClassTable = "pointer table table-sm table-condensed mt-3 table-xsmall";
    public string EditModalClass = "blazored-modal blazored-modal-edit";
    public CultureInfo englCulture = CultureInfo.InvariantCulture;

    public FluentValidationValidator FluentValidationValidator;
    public string inputSelectWithAddCss = "form-select form-select-sm col-lg-2";
    public string inputSelectWithAddCss2 = "form-select form-select-sm col-lg-2";
    public string ItemInfo = "";
    public NumberStyles numberStyle = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;
    public bool read;
    public string TitlePrefix = "XENO-Backoffice | ";
    public bool write;

    [CascadingParameter(Name = "CompanyIdParam")]
    public int CompanyId { get; set; }


    public ClaimsPrincipal AuthUser { get; set; }


    //[Inject] public IStringLocalizer<Locale> L { get; set; }
    // [Inject] public IClientLayoutManager ClientLayoutManager { get; set; }

    public Dictionary<string, int> columPositions { get; set; }
    [Parameter] public EventCallback<bool> IsEditChanged { get; set; }
    [Parameter] public bool isEdit { get; set; }
    [CascadingParameter] public IModalService Modal { get; set; }
    [Inject] protected NavigationManager NavigationManager { get; set; }

    [CascadingParameter] public Task<AuthenticationState> AuthenticationState { get; set; }

    [Parameter] public Guid TenantId { get; set; }
    [Parameter] public string TenantConnectionString { get; set; }

    public string CssSelected { get; set; } = "disabled";

    protected async Task<Guid> GetTenantId(string page)
    {
        var authState = AuthenticationState.Result;
        AuthUser = authState.User;

        if (!AuthUser.Identity.IsAuthenticated)
        {
            NavigationManager.NavigateTo("/login");
            return Guid.Empty;
        }

        if (page == "") write = true;
        else if (AuthUser.IsInRole("admin")) write = true;
        else if (AuthUser.IsInRole("$" + page)) write = true;
        else if (AuthUser.IsInRole(page)) read = true;

        Guid.TryParse(authState.User.FindFirst("tenantid").Value, out var tenantId);
        TenantId = tenantId;
        return tenantId;
    }
}