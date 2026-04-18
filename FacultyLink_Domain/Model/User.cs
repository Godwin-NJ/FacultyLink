using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public int? UpdatedBy { get; set; }
        [JsonIgnore]
        public int? ApprovedBy { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [JsonIgnore]
        public DateTime? ModifiedDate { get; set; } 
        public bool IsActive { get; set; }
        [JsonIgnore]
        public int FailedLoginCount { get; set; }
        public bool IsLocked { get; set; }
        public int? GroupId { get; set; }
        [JsonIgnore]
        public UserGroup? UserGroup { get; set; }
    }
}
