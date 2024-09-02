using System;
using System.Collections.Generic;

namespace oracle_backend.Models
{
    public partial class MvSysSegEmailGroup
    {
        public string SegCompany { get; set; } = null!;
        public string SegGroupName { get; set; } = null!;
        public string SegDescription { get; set; } = null!;
    }
}
