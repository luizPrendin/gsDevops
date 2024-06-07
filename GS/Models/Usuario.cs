using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GS.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "O nome do usuario é obrigatório.")]
        [Column("Nome", TypeName = "varchar(100)")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O email do usuario é obrigatório.")]
        [Column("Email", TypeName = "varchar(100)")]
        public string Email { get; set; }


        [Required(ErrorMessage = "A senha do usuario é obrigatória.")]
        [Column("Senha", TypeName = "varchar(100)")]
        public string Senha { get; set; }


        [Required(ErrorMessage = "A tipo do usuario é obrigatória.")]
        [Column("Tipo", TypeName = "varchar(100)")]
        public string Tipo { get; set; }


        [Required(ErrorMessage = "A data de registro do usuário é obrigatória.")]
        [Column("DataRegistro", TypeName = "timestamp")]
        public DateTime DataRegistro { get; set; }

        public ICollection<Transacao> Transacaos { get; set; }
        public ICollection<Treinamento> Treinamentos { get; set; }
    }
}
