using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GS.Models
{
    [Table("Parceria")]
    public class Parceria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "O nome do parceiro é obrigatório.")]
        [Column("Nome", TypeName = "varchar(100)")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O tipo do parceiro é obrigatório.")]
        [Column("Tipo", TypeName = "varchar(100)")]
        public string Tipo { get; set; }


        [Required(ErrorMessage = "A descricao é obrigatória.")]
        [Column("Descricao", TypeName = "varchar(150)")]
        public string Descricao { get; set; }
    }
}
