using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KnxDataCollector.Model
{
    public partial class RawLogs
    {
        public int LogId { get; set; }
        public DateTime? LogTimestamp { get; set; }
        public string Service { get; set; }
        public string FrameFormat { get; set; }
        public string RawData { get; set; }
    }
}
