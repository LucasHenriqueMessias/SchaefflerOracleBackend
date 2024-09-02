using System;
using System.Collections.Generic;

namespace oracle_backend.Models
{
    public partial class QvSysSsmSystemMail
    {
        public string SsmUsername { get; set; } = null!;
        public DateTime SsmSentDatetime { get; set; }
        public string SsmSubject { get; set; }
        public string SsmMessage { get; set; }
    }
}
