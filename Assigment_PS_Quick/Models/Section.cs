using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assigment_PS_Quick.Models
{
    public class Section
    {
        [Key]
        public int id { get; set; }
        public string sectionName { get; set; } 
        public Department departs { get; set; }

    }
}
