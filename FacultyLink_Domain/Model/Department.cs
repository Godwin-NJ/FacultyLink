using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyLinkDomain.Model
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }
        [Required]
        [Column(TypeName = "varchar(500)")]
        public required string Name { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string? Description { get; set; }
    }
}
