using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PersonalSiteMVC.UI.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }
        [Required(ErrorMessage = "*")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "*")]
        [UIHint("MultilineText")]
        public string Message { get; set; }

    }
}