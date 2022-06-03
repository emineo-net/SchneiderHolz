namespace SchneiderHolzBlazorApp.Models;

public abstract class BaseModel<T> : IBaseModel where T : class
{
    public DateTime? DateNew { get; set; }
    public DateTime? DateLastChange { get; set; }
    public bool CanDelete { get; set; }
    public abstract T GetFields(T data);
}

public interface IBaseModel
{
    DateTime? DateNew { get; set; }
    DateTime? DateLastChange { get; set; }
    bool CanDelete { get; set; }
}