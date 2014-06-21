using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Testing.Models
{
    [Serializable]
    public class MyModel
    {
        [Required(ErrorMessage = "*Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Phone { get; set; }
    }
}