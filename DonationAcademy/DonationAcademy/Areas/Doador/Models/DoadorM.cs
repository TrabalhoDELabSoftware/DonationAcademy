using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DonationAcademy.Areas.Doador.Models
{
    public class DoadorM
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do material!")]
        [Display(Name = "Nome do Material")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 80 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o seu nome!")]
        [Display(Name = "Nome do Doador(a)")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 80 caracteres!")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "A descrição do material deve ser informada!")]
        [Display(Name = "Descrição breve do Material")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição pode exceder (1) caracteres")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "A descrição do material deve ser informada!")]
        [Display(Name = "Descrição detalhada do Material")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição não pode exceder (1) caracteres")]
        public string DescricaoDetalhada { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }


        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        [Required(ErrorMessage = "Informe o telefone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaDoadorId { get; set; }
        public virtual CategoriaDoador CategoriaDoador { get; set; }

        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
