using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimProject.Areas.Clinet.Models
{
    public class Mail
    {
        [Required, Display(Name = "השם שלך")]
        public string FromName { get; set; }
        [Required, Display(Name = "כתובת המייל שלך"), EmailAddress]
        public string FromEmail { get; set; }
        [Required][DisplayName("הכנס בקשתך")]
        public string Message { get; set; }
    }
}