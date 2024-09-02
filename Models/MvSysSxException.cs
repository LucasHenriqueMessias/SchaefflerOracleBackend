using System;
using System.Collections.Generic;

namespace oracle_backend.Models
{
    public partial class MvSysSxException
    {
        public string SxCompany { get; set; } = null!;
        public string SxException { get; set; }
        public string SxModule { get; set; } = null!;
        public string SxTable { get; set; }
        public string SxColumn { get; set; }
        public string SxComparison { get; set; }
        public string SxValue { get; set; }
        public string SxDescription { get; set; } = null!;
        public string SxNote { get; set; }
        public string SxUserCreated { get; set; } = null!;
        public DateTime SxDatetimeCreated { get; set; }
        public string SxUserAltered { get; set; }
        public DateTime? SxDatetimeAltered { get; set; }
    }
}
