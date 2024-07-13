using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CurdInWeb.Models
{
    public class Students
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //public int Age { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Course { get; set; }
        [Required]
        public string Address { get; set; }
        
    }
}