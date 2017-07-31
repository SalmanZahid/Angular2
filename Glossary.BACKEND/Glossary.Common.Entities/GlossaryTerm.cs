using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Glossary.Common.Entities
{
    [Table("GlossaryTerm")]
    public class GlossaryTerm
    {
        [Key]
        public int Id { get; set; }

        [Column("Term", TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string term { get; set; }

        [Column("Definition", TypeName="varchar")]
        [StringLength(250)]
        [Required]
        public string definition { get; set; }
    }
}
