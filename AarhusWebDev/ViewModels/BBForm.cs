using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AarhusWebDev.ViewModels
{
    public class BBForm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Message { get; set; }
    }
}