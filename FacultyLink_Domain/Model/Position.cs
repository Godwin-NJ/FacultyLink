using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyLinkDomain.Model
{
    /// <summary>
    /// This will be used to profile the position of the faculty members and lecturers. 
    /// For example, Professor, Associate Professor, Assistant Professor, etc.
    /// </summary>
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PositionId { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
