using Blazored.Modal;
using Microsoft.AspNetCore.Components;

namespace SchneiderHolzBlazorApp.Shared;

public partial class Confirm
{
    [CascadingParameter] private BlazoredModalInstance BlazoredModal { get; set; }
}