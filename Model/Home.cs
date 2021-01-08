using System;
using System.Collections.Generic;

namespace KnxDataCollector.Model
{
    public partial class Home
    {
        public int ID { get; set; }
        public string? HomeText { get; set; }
        public DateTime? Time { get; set; }
    }
}
