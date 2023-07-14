using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assigment_PS_Quick.Models
{
    public class EntryData
    {
        [Key]
        public int fileNo { get; set; }
        public DateTime fileDate { get; set; }
        public int departCode { get; set; }
        public int sectionCode { get; set; }
        public string filePath { get; set; }
        public string subject { get; set; }

    }
}
