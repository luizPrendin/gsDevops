using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GS.Models
{
    [Table("MaterialReciclado")]
    public class MaterialReciclado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "O tipo do anuncio é obrigatório.")]
        [Column("Tipo", TypeName = "varchar(100)")]
        public string Tipo { get; set; }


        [Required(ErrorMessage = "A descricao é obrigatória.")]
        [Column("Descricao", TypeName = "varchar(150)")]
        public string Descricao { get; set; }


        [Required(ErrorMessage = "A quantidade do material é obrigatória.")]
        [Column("Quantidade")]
        public int Quantidade { get; set; }


        [Required(ErrorMessage = "A Data de Coleta é obrigatória.")]
        [Column("DataColeta", TypeName = "timestamp")]
        public DateTime DataColeta { get; set; }


        [Required(ErrorMessage = "A origem é obrigatória.")]
        [Column("Origem", TypeName = "varchar(100)")]
        public string Origem { get; set; }


        public ICollection<Transacao> Transacaos { get; set; }

    }
}
