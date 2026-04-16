using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyLinkDomain.Model
{
    public class UserGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupId { get; set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public required string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(250)")]
        public required string Description { get; set; }
    }
}
