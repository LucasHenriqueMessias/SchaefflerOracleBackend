using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace oracle_backend.Models
{

    public partial class TbSysSemEmailGroupMember
    {

        public string SemCompany { get; set; } = null;
        public string SemGroupName { get; set; } = null!;
        public string SemGroupMember { get; set; } = null!;
        public string SemMemberDomain { get; set; } = null!;
        public string SemUserCreated { get; set; } = null;
        public DateTime? SemDatetimeCreated { get; set; } = null;
        public string SemUserAltered { get; set; } = null;
        public DateTime? SemDatetimeAltered { get; set; } = null;
    }
}
