using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GS.Models
{
    [Table("Transacao")]
    public class Transacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "A Data da Transacao é obrigatória.")]
        [Column("DataTransacao", TypeName = "timestamp")]
        public DateTime DataTransacao { get; set; }


        [Required(ErrorMessage = "A quantidade do material é obrigatória.")]
        [Column("Quantidade")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O Status da transação é obrigatório.")]
        [Column("Status", TypeName = "varchar(50)")]
        public string Status { get; set; }
        

        [ForeignKey("MaterialRecicladoId")]
        public int MaterialRecicladoId { get; set; }
        public MaterialReciclado MaterialReciclado { get; set; }


        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
