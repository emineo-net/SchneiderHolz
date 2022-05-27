using System;
using System.Collections.Generic;

namespace SchneiderHolzApi.Models
{
    public partial class TransportOrder
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
    }
}
