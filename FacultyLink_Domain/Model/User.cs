using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyLinkDomain.Model
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required]
        public required string FirstName { get; set; }
        [Column(TypeName = "varchar(500)")]
        [Required]
        public required string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public required string Email { get; set; } // email will serve as username
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [Required]
        public required string Password { get; set; }       
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? ModifiedDate { get; set; } 
        public bool IsActive { get; set; } 
        public int FailedLoginCount { get; set; }
        public bool IsLocked { get; set; }
        public int? GroupId { get; set; }
        public UserGroup? UserGroup { get; set; }
    }
}
