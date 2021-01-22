using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KnxDataCollector.Model
{
    public partial class KnxProcesses
    {
        public long Pid { get; set; }
        public string ProcessName { get; set; }
        public string ProcessIp { get; set; }
        public string ProcessType { get; set; }
        public string ProcessedFile { get; set; }
        public int? ActualTelegramNr { get; set; }
        public int? TotalTelegramNr { get; set; }
    }
}
