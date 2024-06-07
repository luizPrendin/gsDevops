using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GS.Models
{
    [Table("Treinamento")]
    public class Treinamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "O Titulo do treinamento é obrigatório.")]
        [Column("Titulo", TypeName = "varchar(100)")]
        public string Titulo { get; set; }


        [Required(ErrorMessage = "A descrição do treinamento é obrigatória.")]
        [Column("Descricao", TypeName = "varchar(100)")]
        public string Descricao { get; set; }


        [Required(ErrorMessage = "A data de inicio do freinamento é obrigatória.")]
        [Column("DataInicio", TypeName = "timestamp")]
        public DateTime DataInicio { get; set; }


        [Required(ErrorMessage = "A data de fim do treinamento é obrigatória.")]
        [Column("DataFim", TypeName = "timestamp")]
        public DateTime DataTransacao { get; set; }


        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
