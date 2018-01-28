using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AgainArt.Models
{
    public class Email
    {
        public string Name { get; set; }

        [DisplayName("Email")]
        public string From { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        [DisplayName("Message")]
        public string Body { get; set; }
    }
}