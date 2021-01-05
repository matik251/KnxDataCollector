using System;
using System.Collections.Generic;

namespace KnxDataCollector.Model
{
    public partial class KnxTelegrams
    {
        public long Tid { get; set; }
        public string TimestampS { get; set; }
        public DateTime Timestamp { get; set; }
        public string Service { get; set; }
        public string FrameFormat { get; set; }
        public string RawData { get; set; }
        public int? RawDataLength { get; set; }
        public string FileName { get; set; }
    }
}
