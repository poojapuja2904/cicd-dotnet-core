using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace techwork_after_america_return.ViewModels
{
    public class ContactViewModel
    {

        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "too long text")]
        public string Message { get; set; }
    }
}
