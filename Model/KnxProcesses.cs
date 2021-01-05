using System;
using System.Collections.Generic;

namespace KnxDataCollector.Model
{
    public partial class KnxProcesses
    {
        public int Pid { get; set; }
        public string ProcessName { get; set; }
        public string ProcessIp { get; set; }
        public string ProcessType { get; set; }
    }
}
