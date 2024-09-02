using System;
using System.Collections.Generic;

namespace oracle_backend.Models
{
    public partial class MvSysSjJob
    {
        public string SjProcedureName { get; set; } = null!;
        public string SjDescription { get; set; } = null!;
        public string SjUserCreated { get; set; } = null!;
        public DateTime SjDatetimeCreated { get; set; }
        public string SjUserUpdated { get; set; }
        public DateTime? SjDatetimeUpdated { get; set; }
    }
}
