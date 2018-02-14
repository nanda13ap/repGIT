using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgainArt.Models
{
    public class Email
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Email")]
        [EmailAddress]
        public string From { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        [Required]
        [DisplayName("Message")]
        [StringLength(10000, MinimumLength = 5, ErrorMessage = "Your message can be from 5 to 10000 characters.")]
        public string Body { get; set; }
    }
}