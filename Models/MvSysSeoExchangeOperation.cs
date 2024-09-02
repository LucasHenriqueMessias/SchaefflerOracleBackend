using System;
using System.Collections.Generic;

namespace oracle_backend.Models
{
    public partial class MvSysSeoExchangeOperation
    {
        public string SeoCompany { get; set; } = null!;
        public string SeoSourceHost { get; set; } = null!;
        public string SeoDestHost { get; set; } = null!;
        public string SeoOperation { get; set; } = null!;
        public string SeoUserAlt { get; set; } = null!;
        public DateTime? SeoDateAlt { get; set; }
        public string SeoDescription { get; set; } = null!;
        public string SeoSourceFtpUser { get; set; } = null!;
        public string SeoDestFtpUser { get; set; } = null!;
    }
}
