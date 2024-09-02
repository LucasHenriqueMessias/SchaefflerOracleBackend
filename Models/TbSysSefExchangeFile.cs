using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace oracle_backend.Models
{
    public partial class TbSysSefExchangeFile
    {
        public string SefCompany { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SefId { get; set; }
        public string SefOperation { get; set; }
        public string SefSourceHost { get; set; }
        public string SefSourceDir { get; set; }
        public string SefSourceFile { get; set; }
        public string SefDestHost { get; set; }
        public string SefDestDir { get; set; }
        public string SefDestFile { get; set; }
        public string SefBackupDir { get; set; }
        public string SefShare { get; set; }
        public string SefDestShare { get; set; }
        public string SefDeleteSource { get; set; }
        public string SefAppend { get; set; }
        public string SefUserAlt { get; set; }
        public DateTime SefDateAlt { get; set; }
        public string SefSourceFtpUser { get; set; }
        public string SefDestFtpUser { get; set; }
        public string SefModule { get; set; }
    }
}
