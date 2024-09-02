using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace oracle_backend.Models
{
    public partial class MvSysSjpJobParameter
    {

        public string SjpProcedureName { get; set; } = null!;
        public string SjDescription { get; set; }
        public string SjpParameterName { get; set; } = null!;
        public string SjpDescription { get; set; } = null!;
        public byte SjpSequence { get; set; }
        public string SjpDatatype { get; set; } = null!;
        public string SjpUserCreated { get; set; } = null!;
        public DateTime SjpDatetimeCreated { get; set; }
        public string SjpUserUpdated { get; set; }
        public DateTime? SjpDatetimeUpdated { get; set; }

    }
}
