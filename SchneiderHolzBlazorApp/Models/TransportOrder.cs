namespace SchneiderHolzBlazorApp.Models;

public class TransportOrder : IBaseModel
{
    public int Id { get; set; }
    public string PackageNumber { get; set; } = "";
    public string Location { get; set; } = "";
    public string Position { get; set; } = "";
    public string Type { get; set; } = "";
    public string Target { get; set; } = "";
    public string Status { get; set; } = "";
    public string Priority { get; set; } = "";
    public string Source { get; set; } = "";
    public DateTime Generated { get; set; } = DateTime.Now;
    public bool Ignore { get; set; } = false;
    public DateTime? DateNew { get; set; } = DateTime.Now;
    public DateTime? DateLastChange { get; set; }
    public bool CanDelete { get; set; } = true;

    public override string ToString()
    {
        return
            $"PackageNumber: {PackageNumber} \nLocation: {Location}  \nPosition: {Position}  \nType: {Type} \nTarget: {Target}  \nStatus: {Status}  \nPriority: {Priority}  \nSource: {Source}  \nGenerated: {Generated.ToLongDateString()}  \nIgnore: {Ignore}";
    }
}