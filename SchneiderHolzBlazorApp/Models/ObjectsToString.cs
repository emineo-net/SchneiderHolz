namespace SchneiderHolzBlazorApp.Models
{
    public class ObjectsToString
    {
        public string CheckoutProductToString(TransportOrder transportOrder)
        {
            return $"PackageNumber: {transportOrder.PackageNumber}\nLocation: {transportOrder.Location}\nPosition: {transportOrder.Position}\nType: " +
                $"{transportOrder.Type}\nTarget: {transportOrder.Target}\nStatus: {transportOrder.Status}\nPriority: {transportOrder.Priority}\nSource: " +
                $"{transportOrder.Source}\nGenerated: {transportOrder.Generated.ToLongDateString()}\nIgnore: {transportOrder.Ignore}";
        }

    }
}
