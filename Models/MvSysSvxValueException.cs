using System;
using System.Collections.Generic;

namespace oracle_backend.Models
{
    public partial class MvSysSvxValueException
    {
        public string SvxCompany { get; set; } = null!;
        public int SvxException { get; set; } 
        public string SxDescription { get; set; } = null!;
        public string SvxAlphanumericValue { get; set; }
        public decimal? SvxNumericValue { get; set; }
        public DateTime? SvxDatetimeValue { get; set; }
        public string SvxActive { get; set; } = null!;
        public string SvxUserCreated { get; set; } = null!;
        public DateTime SvxDatetimeCreated { get; set; }
        public string SvxUserAltered { get; set; }
        public DateTime? SvxDatetimeAltered { get; set; }

        
    }
}
