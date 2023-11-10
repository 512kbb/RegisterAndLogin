using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterAndLogin.Models
{
    public class User
    {
        [Key]
        [Column("id_user")]
        public int IdUser { get; set; }
        [Required]
        [Column("username")]
        [MinLength(2)]
        public string? Username { get; set; }
        [Required]
        [Column("password")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string? PasswordConfirm { get; set; }
        [Required]
        [Column("email")]
        [EmailAddress]
        [UniqueEmail]
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}