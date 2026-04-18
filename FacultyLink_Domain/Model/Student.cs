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
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(500)")]
        public required string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(500)")]
        public required string LastName { get; set; }       
        [Column(TypeName = "varchar(500)")]
        public string? OtherName { get; set; }
        [Required]       
        public DateTime DateOfBirth { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public required string EmailAddress { get; set; }
        public bool IsActive { get; set; } = true;
        [Required]
        [Column(TypeName = "varchar(500)")]
        public required string RegistrationNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        [JsonIgnore]
        public string? ProfilePictureUrl { get; set; }
        public int FacultyId { get; set; }      
        [ForeignKey("FacultyId")]
        [JsonIgnore]
        public Faculty Faculty { get; set; }
        public int DepartmentId { get; set; }
        [JsonIgnore]
        public Department Department { get; set; }
        public bool HasGraduated { get; set; } = false;
        [Required]
        public required DateTime StartDate { get; set; }
        public DateTime? GraduatedDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int? StaffId { get; set; }
        [JsonIgnore]
        public Staff? AssignedAdvisor { get; set; }
        public int? GroupId { get; set; }
        [JsonIgnore]
        public UserGroup? UserGroup { get; set; }

    }
}
