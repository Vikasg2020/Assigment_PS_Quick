using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assigment_PS_Quick.Models
{
    public class Department
    {
        [Key]
        public int id { get; set; }
        public string departName { get; set; } 
        public List<Section> sectionList { get; set; }

    }
}
