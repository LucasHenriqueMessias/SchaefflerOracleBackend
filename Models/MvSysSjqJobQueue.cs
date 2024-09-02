using System;
using System.Collections.Generic;

namespace oracle_backend.Models
{
    public partial class MvSysSjqJobQueue
    {
        public string SjqProcedureName { get; set; } = null!;
        public string SjDescription { get; set; }
        public int SjqJob { get; set; }
        public DateTime? SjqDatetimeScheduled { get; set; }
        public string SjqStatus { get; set; } = null!;
        public string SjqInterval { get; set; }
        public string SjqSunday { get; set; } = null!;
        public string SjqMonday { get; set; } = null!;
        public string SjqTuesday { get; set; } = null!;
        public string SjqWednesday { get; set; } = null!;
        public string SjqThursday { get; set; } = null!;
        public string SjqFriday { get; set; } = null!;
        public string SjqSaturday { get; set; } = null!;
        public byte? SjqTotalIteration { get; set; }
        public byte? SjqCurrentIteration { get; set; }
        public string SjqMessage { get; set; }
        public string SjqFollowedByMail { get; set; } = null!;
        public string SjqUserCreated { get; set; } = null!;
        public DateTime SjqDatetimeCreated { get; set; }
        public string SjqUserUpdated { get; set; }
        public DateTime? SjqDatetimeUpdated { get; set; }
    }
}
