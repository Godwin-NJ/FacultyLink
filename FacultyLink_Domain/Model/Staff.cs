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
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? OtherName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        [Required]
        public string StaffNumber { get; set; }
        [JsonIgnore]
        public string? ProfilePictureUrl { get; set; }
        public int FacultyId { get; set; }
        [JsonIgnore]
        public Faculty Faculty { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [JsonIgnore]
        public Department Department { get; set; }
        [Required]
        public int? GroupId { get; set; }
        [JsonIgnore]
        public UserGroup? UserGroup { get; set; }
        public bool IsActive { get; set; } = true;
        [Required]
        public bool IsAcademic { get; set; }        
        public int? PositionId { get; set; }
        [JsonIgnore]
        public Position? Position { get; set; }
        public DateTime? ModifiedDate { get; set; } 
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
