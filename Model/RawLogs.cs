using System;
using System.Collections.Generic;

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
