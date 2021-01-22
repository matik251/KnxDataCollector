using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KnxDataCollector.Model
{
    public partial class XmlFiles
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
