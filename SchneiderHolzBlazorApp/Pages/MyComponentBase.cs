using System.Globalization;
using Blazored.FluentValidation;
using Microsoft.AspNetCore.Components.Authorization;

namespace SchneiderHolzBlazorApp.Pages;

public class MyComponentBase : ComponentBase
{
    public string CssClassTable = "pointer table table-sm table-condensed mt-3 table-xsmall";
    public string EditModalClass = "blazored-modal blazored-modal-edit";
    public CultureInfo EnglCulture = CultureInfo.InvariantCulture;

    public FluentValidationValidator FluentValidationValidator;
    public string InputSelectWithAddCss = "form-select form-select-sm col-lg-2";
    public string InputSelectWithAddCss2 = "form-select form-select-sm col-lg-2";
    public string ItemInfo = "";
    public NumberStyles NumberStyle = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;
    public bool Read;
    public string TitlePrefix = "XENO-Backoffice | ";
    public bool writable;

    [CascadingParameter(Name = "CompanyIdParam")]
    public int CompanyId { get; set; }


    public ClaimsPrincipal AuthUser { get; set; }


    //[Inject] public IStringLocalizer<Locale> L { get; set; }
    // [Inject] public IClientLayoutManager ClientLayoutManager { get; set; }

    public Dictionary<string, int> columPositions { get; set; }
    [Parameter] public EventCallback<bool> IsEditChanged { get; set; }
    [Parameter] public bool IsEdit { get; set; }
    [CascadingParameter] public IModalService Modal { get; set; }
    [Inject] protected NavigationManager NavigationManager { get; set; }

    [CascadingParameter] public Task<AuthenticationState> AuthenticationState { get; set; }

    [Parameter] public Guid TenantId { get; set; }
    [Parameter] public string TenantConnectionString { get; set; }

    public string CssSelected { get; set; } = "disabled";

}