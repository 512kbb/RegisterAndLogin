using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLogin.Models
{
    public class LoginUser
    {
        [Required]
        [DisplayName("Email")]
        public string LoginEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string? LoginPassword { get; set; }
    }
}