using System.ComponentModel.DataAnnotations;

namespace Glossary.BLL.DTOs
{
    public class GlossaryTermDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Term is required")]
        [StringLength(50)]
        public string term { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Definition is required")]
        public string definition { get; set; }
    }
}
