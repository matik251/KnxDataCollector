using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KnxDataCollector.Model
{
    public partial class Home
    {
        public string HomeText { get; set; }
        public DateTime? Time { get; set; }
        public int? Id { get; set; }
    }
}
