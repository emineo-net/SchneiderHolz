namespace SchneiderHolzBlazorApp.Shared;

public partial class Confirm
{
    [CascadingParameter] private BlazoredModalInstance BlazoredModal { get; set; }
}