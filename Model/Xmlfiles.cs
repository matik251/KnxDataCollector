using System;
using System.Collections.Generic;

namespace KnxDataCollector.Model
{
    public partial class Xmlfiles
    {
        public int Fid { get; set; }
        public string FileName { get; set; }
        public string Xmldata { get; set; }
        public int? IsProcessed { get; set; }
        public int? ProcessingPercentage { get; set; }
        public int? TelegramsCount { get; set; }
        public int? CancellationToken { get; set; }
    }
}
