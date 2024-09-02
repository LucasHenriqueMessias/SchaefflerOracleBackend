using System;
using System.Collections.Generic;

namespace oracle_backend.Models
{
    public partial class QvSysSelExchangeLog
    {
        public string SelCompany { get; set; } = null!;
        public long SelId { get; set; }
        public string SelType { get; set; } = null!;
        public DateTime SelDate { get; set; }
        public string SelMessage { get; set; } = null!;
        public string SelUserAlt { get; set; } = null!;
        public DateTime? SelDateAlt { get; set; }
    }
}
