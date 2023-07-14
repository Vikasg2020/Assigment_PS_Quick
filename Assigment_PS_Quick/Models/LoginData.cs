using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assigment_PS_Quick.Models
{
    public class LoginData
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
