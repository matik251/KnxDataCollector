using System;
using System.Collections.Generic;
using System.Xml;

namespace KnxDataCollector.Models
{
    public partial class RawLogs
    {
        public int LogId { get; set; }
        public DateTime? LogTimestamp { get; set; }
        public string Service { get; set; }
        public string FrameFormat { get; set; }
        public string RawData { get; set; }
    }

    public class Telegram
    {
        public long TID { get; set; }

        public string TimestampS { get; set; }
        public DateTime Timestamp { get; set; }

        public string Service { get; set; }
        public string FrameFormat { get; set; }

        public string RawData { get; set; }
        public int RawDataLength { get; set; }

        public string FileName { get; set; }
    }

    public enum KnxServices
    {
        L_Busmon_ind
    }

    public class KnxDecoderWorkers
    {
        public int Id { get; set; }
        public int IsBusy { get; set; }
    }

    public class TelegramXml
    {
        public string FileName { get; set; }
        public XmlDocument XMLData { get; set; }
        public int IsProcessed { get; set; }
        public int ProcessingPercentage { get; set; }
    }

    public enum KnxTelegramByteLengths : int
    {
        None = 0,
        Short = 24,
        ShortLong = 38,
        NormalShort = 40,
        Normal = 42,
        NormalLong = 44,
    }

}
