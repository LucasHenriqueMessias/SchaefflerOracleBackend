using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

#nullable disable

namespace oracle_backend.Models
{
    public partial class MvSysSemEmailGroupMember
    {
       
        public string SemGroupName { get; set; }
        public string SemGroupMember { get; set; }
        public string SemMemberDomain { get; set; }

        public string SemCompany { get; set; } = null;
        [JsonIgnore]
        public string PeName { get; } = null;
    }
}
