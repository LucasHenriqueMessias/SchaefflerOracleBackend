using System;
using System.Collections.Generic;

namespace oracle_backend.Models
{
    public partial class MvSysSehExchangeHost
    {
        public string SehCompany { get; set; } = null!;
        public string SehHost { get; set; } = null!;
        public short SehPortFtp { get; set; }
        public string SehUsername { get; set; }
        public string SehPassword { get; set; }
        public string SehFileProtocol { get; set; } = null!;
        public string SehUserAlt { get; set; } = null;
        public DateTime? SehDateAlt { get; set; } = null;
    }
}
