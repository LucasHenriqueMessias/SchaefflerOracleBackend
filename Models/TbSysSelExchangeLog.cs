using System;
using System.Collections.Generic;

#nullable disable

namespace oracle_backend.Models
{
    public partial class TbSysSelExchangeLog
    {
        public string SelCompany { get; set; }
        public long SelId { get; set; }
        public string SelType { get; set; }
        public DateTime SelDate { get; set; }
        public string SelMessage { get; set; }
        public string SelUserAlt { get; set; }
        public DateTime SelDateAlt { get; set; }
    }
}
