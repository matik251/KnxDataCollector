using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KnxDataCollector.Model
{
    public partial class DecodedTelegrams
    {
        public long Tid { get; set; }
        public string TimestampS { get; set; }
        public DateTime Timestamp { get; set; }
        public string Service { get; set; }
        public string FrameFormat { get; set; }
        public string SourceAddress { get; set; }
        public string GroupAddress { get; set; }
        public string DeviceName { get; set; }
        public string Data { get; set; }
        public float DataFloat { get; set; }
        public string SerializedData { get; set; }
    }
}
