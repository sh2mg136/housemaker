using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace themesite.Models
{

    public class ContactMailModel
    {
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required]
        [MinLength(4)]
        public string Message { get; set; }

        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
    }

}